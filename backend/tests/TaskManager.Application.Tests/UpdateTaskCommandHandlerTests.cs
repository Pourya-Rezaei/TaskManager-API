using FluentAssertions;
using CancellationToken = System.Threading.CancellationToken;
using Guid = System.Guid;
using KeyNotFoundException = System.Collections.Generic.KeyNotFoundException;
using NSubstitute;
using TaskManager.Application.Commands.Tasks;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Enums;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Application.Tests
{
    public class UpdateTaskCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ExistingTask_ShouldUpdateFields()
        {
            // Arrange
            var taskId = Guid.NewGuid();
            var existingTask = new TaskItem { Id = taskId, Title = "Old Title" };
            var repository = Substitute.For<ITaskRepository>();
            repository.GetByIdAsync(taskId).Returns(existingTask);
            var handler = new UpdateTaskCommandHandler(repository);
            var command = new UpdateTaskCommand(
                Id: taskId,
                Title: "New Title",
                Description: "New Desc",
                Priority: TaskPriority.High,
                DueDate: null,
                CategoryId: null
            );

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            existingTask.Title.Should().Be("New Title");
            existingTask.Description.Should().Be("New Desc");
            existingTask.Priority.Should().Be(TaskPriority.High);
            existingTask.UpdatedAt.Should().NotBeNull();
        }

        [Fact]
        public async Task Handle_NonExistingTask_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            var repository = Substitute.For<ITaskRepository>();
            repository.GetByIdAsync(Arg.Any<Guid>()).Returns((TaskItem?)null);
            var handler = new UpdateTaskCommandHandler(repository);
            var command = new UpdateTaskCommand(
                Id: Guid.NewGuid(),
                Title: "Title",
                Description: null,
                Priority: TaskPriority.Low,
                DueDate: null,
                CategoryId: null
            );

            // Act
            var act = async () => await handler.Handle(command, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<KeyNotFoundException>();
        }
    }
}