using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationWithTests;
using Task = WebApplicationWithTests.Task;

namespace TestProject1
{
    internal class TaskManagerTest
    {
        private TaskManager _taskManager;
        [SetUp]
        public void Setup()
        {
            _taskManager = new TaskManager();
        }
        [Test]
        public void AddTask_ShouldIncreaseTaskCount()
        {
            // Arrange
            var task = new Task("Test task");
            // Act
            _taskManager.AddTask(task);
            // Assert
            Assert.AreEqual(1, _taskManager.GetTasks().Count);
        }
        //////////////////////////////////////////////////////////////

        [Test]
        public void RemoveTask_ExistingTask_ShouldDecreaseTaskCount()
        {
            // Arrange
            var task = new Task("Test task");
            _taskManager.AddTask(task);

            // Act
            _taskManager.RemoveTask(task.Id);

            // Assert
            Assert.AreEqual(0, _taskManager.GetTasks().Count);
        }

        [Test]
        public void RemoveTask_NonExistingTask_ShouldNotChangeTaskCount()
        {
            // Arrange
            var task = new Task("Test task");
            _taskManager.AddTask(task);

            // Act
            _taskManager.RemoveTask(999); // Non-existing task ID

            // Assert
            Assert.AreEqual(1, _taskManager.GetTasks().Count);
        }

        [Test]
        public void MarkTaskAsCompleted_ExistingTask_ShouldMarkTaskAsCompleted()
        {
            // Arrange
            var task = new Task("Test task");
            _taskManager.AddTask(task);

            // Act
            _taskManager.MarkTaskAsCompleted(task.Id);

            // Assert
            var updatedTask = _taskManager.GetTaskById(task.Id);
            Assert.IsTrue(updatedTask.IsCompleted);
        }

        [Test]
        public void MarkTaskAsCompleted_NonExistingTask_ShouldNotMarkTaskAsCompleted()
        {
            // Arrange
            var task = new Task("Test task");
            _taskManager.AddTask(task);

            // Act
            _taskManager.MarkTaskAsCompleted(999); // Non-existing task ID

            // Assert
            var updatedTask = _taskManager.GetTaskById(task.Id);
            Assert.IsFalse(updatedTask.IsCompleted);
        }

        [Test]
        public void GetTasks_ShouldReturnAllTasks()
        {
            // Arrange
            var task1 = new Task("Task 1");
            var task2 = new Task("Task 2");
            _taskManager.AddTask(task1);
            _taskManager.AddTask(task2);

            // Act
            var allTasks = _taskManager.GetTasks();

            // Assert
            Assert.AreEqual(2, allTasks.Count);
            Assert.Contains(task1, allTasks);
            Assert.Contains(task2, allTasks);
        }
    }
}
