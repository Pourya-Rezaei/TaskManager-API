using FluentAssertions;
using NSubstitute;
using TaskManager.Application.Queries.Tasks;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Application.Tests
{
    public class GetAllTasksQueryHandlerTests
    {
        [Fact]
        public async Task Handle_WhenTasksExist_ShouldReturnAllTasks()
        {
            // Arrange
            var tasks = new List<TaskItem>
            {
                new TaskItem { Id = Guid.NewGuid(), Title = "Task 1" },
                new TaskItem { Id = Guid.NewGuid(), Title = "Task 2" }
            };
            var repository = Substitute.For<ITaskRepository>();
            repository.GetAllAsync().Returns(tasks);
            var handler = new GetAllTasksQueryHandler(repository);

            // Act
            var result = await handler.Handle(new GetAllTasksQuery(), CancellationToken.None);

            // Assert
            result.Should().HaveCount(2);
        }

        [Fact]
        public async Task Handle_WhenNoTasksExist_ShouldReturnEmptyList()
        {
            // Arrange
            var repository = Substitute.For<ITaskRepository>();
            repository.GetAllAsync().Returns(new List<TaskItem>());
            var handler = new GetAllTasksQueryHandler(repository);

            // Act
            var result = await handler.Handle(new GetAllTasksQuery(), CancellationToken.None);

            // Assert
            result.Should().BeEmpty();
        }

        [Fact]
        public async Task Handle_WhenTasksExist_ShouldMapTitleCorrectly()
        {
            // Arrange
            var tasks = new List<TaskItem>
            {
                new TaskItem { Id = Guid.NewGuid(), Title = "My Task" }
            };
            var repository = Substitute.For<ITaskRepository>();
            repository.GetAllAsync().Returns(tasks);
            var handler = new GetAllTasksQueryHandler(repository);

            // Act
            var result = await handler.Handle(new GetAllTasksQuery(), CancellationToken.None);

            // Assert
            result.First().Title.Should().Be("My Task");
        }
    }
}