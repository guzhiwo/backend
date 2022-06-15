using System;
using System.Collections.Generic;
using TaskBoard;
using Xunit;

namespace TaskBoardTest
{
    public class TaskTests
    {
        [Fact]
        public void CreateTaskWithDescription()
        {
            string taskName = "History";
            string taskDescription = "Write a report, learn definitions";

            Task newTask = new Task(taskName, taskDescription, Priority.Middle);

            Assert.Equal(taskName, newTask.TaskName);
            Assert.Equal(taskDescription, newTask.TaskDescription);
            Assert.Equal(Priority.Middle, newTask.TaskPriority);
        }

        [Fact]
        public void ChangeTaskWithNewName()
        {
            string taskName = "History";
            string taskNameNew = "Philosophy";
            string taskDescription = "Write a report, learn definitions";
            Task newTask = new Task(taskName, taskDescription, Priority.Middle);

            newTask.TaskName = taskNameNew;

            Assert.Equal(taskNameNew, newTask.TaskName);
        }

        [Fact]
        public void ChangeTaskWithNewDescription()
        {
            string taskName = "History";
            string taskDescription = "Write a report, learn definitions";
            string taskDescriptionNew = "Send report by e-mail";
            Task newTask = new Task(taskName, taskDescription, Priority.Middle);

            newTask.TaskDescription = taskDescriptionNew;

            Assert.Equal(taskDescriptionNew, newTask.TaskDescription);
        }

        [Fact]
        public void ChangeTaskNewPriority()
        {
            string taskName = "History";
            string taskDescription = "Write a report, learn definitions";
            Task newTask = new Task(taskName, taskDescription, Priority.Middle);

            newTask.TaskPriority = Priority.High;

            Assert.Equal(Priority.High, newTask.TaskPriority);
        }
    }

    public class ColumnTest
    {
        [Fact]
        public void CreateColumnWithoutTasks()
        {
            string columnName = "Studies";

            Column newColumn = new Column(columnName);

            Assert.Equal(columnName, newColumn.ColumnName);
            Assert.Empty(newColumn.LookAllTasks());
        }

        [Fact]
        public void ChangeColumnNameWithNewName()
        {
            string newColumnName = "Student life";
            string columnName = "Studies";
            Column newColumn = new Column(columnName);

            newColumn.ColumnName = newColumnName;

            Assert.Equal(newColumnName, newColumn.ColumnName);
        }

        [Fact]
        public void ChangeColumnNameWithNewTask()
        {
            string columnName = "Studies";
            string taskName = "History";
            string taskDescription = "Write a report, learn definitions";
            Task newTask = new Task(taskName, taskDescription, Priority.Middle);
            Column newColumn = new Column(columnName);

            newColumn.AddTask(newTask);

            Assert.Equal(newTask, newColumn.LookAllTasks()[0]);
        }

        [Fact]
        public void GetTaskFromColumn()
        {
            string columnName = "Studies";
            string taskName = "History";
            string taskDescription = "Write a report, learn definitions";
            Task newTask = new Task(taskName, taskDescription, Priority.Middle);
            Column newColumn = new Column(columnName);
            newColumn.AddTask(newTask);

            Task? neededTask = newColumn.GetTask(newTask.UnicalID);

            Assert.Equal(newTask, neededTask);
        }

        [Fact]
        public void DeleteTaskInColumn()
        {
            string columnName = "Studies";
            string taskName = "History";
            string taskDescription = "Write a report, learn definitions";
            Task newTask = new Task(taskName, taskDescription, Priority.Middle);
            Column newColumn = new Column(columnName);
            newColumn.AddTask(newTask);

            newColumn.DeleteTask(newTask.UnicalID);

            Assert.Null(newColumn.GetTask(newTask.UnicalID));
        }

        [Fact]
        public void LookAllTaskFromColumn()
        {
            Task firstTask = new Task("History", "Write a report, learn definitions", Priority.Middle);
            Task secondTask = new Task("Philosophy", "Send report by e-mail", Priority.Middle);
            string columnName = "Studies";
            Column newColumn = new Column(columnName);
            newColumn.AddTask(firstTask);
            newColumn.AddTask(secondTask);

            List<Task> listOfTask = newColumn.LookAllTasks();

            Assert.Equal(new List<Task>() { firstTask, secondTask }, listOfTask);
        }

        [Fact]
        public void AddTaskWithExistName()
        {
            Task firstTask = new Task("History", "Write a report, learn definitions", Priority.Middle);
            Task secondTask = new Task("History", "Write a report, learn definitions", Priority.Middle);
            string columnName = "Studies";
            Column newColumn = new Column(columnName);
            newColumn.AddTask(firstTask);

            newColumn.AddTask(secondTask);

            Assert.Throws<System.Exception>(() => newColumn.AddTask(secondTask));
        }
    }

    public class BoardTest
    {
        [Fact]
        public void CreateBoardWithoutColumns()
        {
            string boardName = "Activity board";

            Board newBoard = new Board(boardName);

            Assert.Equal(boardName, newBoard.BoardName);
            Assert.Empty(newBoard.LookAllColumn());
        }

        [Fact]
        public void AddColumnInBoardWillBeAdded()
        {
            string boardName = "Activity board";
            string columnName = "Studies";
            Board newBoard = new Board(boardName);
            Column newcolumn = new Column(columnName);

            newBoard.AddColumn(newcolumn);

            Assert.Equal(newcolumn, newBoard.LookAllColumn()[0]);
        }

        [Fact]
        public void AddTaskIntoColumn_AddedTask()
        {
            string taskName = "History";
            string taskDescription = "Write a report, learn definitions";
            Task newTask = new Task(taskName, taskDescription, Priority.Middle);
            string boardName = "Activity board";
            string columnName = "Studies";
            Board newBoard = new Board(boardName);
            Column newcolumn = new Column(columnName);
            newBoard.AddColumn(newcolumn);

            newBoard.AddTaskIntoColumn(newTask);

            Assert.Equal(newTask, newcolumn.LookAllTasks()[0]);
        }

        [Fact]
        public void GetTaskFromBoard_ReturnFindTask()
        {
            string taskName = "History";
            string taskDescription = "Write a report, learn definitions";
            Task newTask = new Task(taskName, taskDescription, Priority.Middle);
            string boardName = "Activity board";
            string columnName = "Studies";
            Board newBoard = new Board(boardName);
            Column newcolumn = new Column(columnName);
            newBoard.AddColumn(newcolumn);
            newBoard.AddTaskIntoColumn(newTask);

            Task findTask = newBoard.GetTask(newTask.UnicalID);

            Assert.Equal(newTask, findTask);
        }

        [Fact]
        public void GetColumnFromBoard_ReturnFindColumn()
        {
            string boardName = "Activity board";
            string columnName = "Studies";
            Board newBoard = new Board(boardName);
            Column newcolumn = new Column(columnName);
            newBoard.AddColumn(newcolumn);

            Column findColumn = newBoard.GetColumn(newcolumn.UnicalID);

            Assert.Equal(newcolumn, findColumn);
        }

        [Fact]
        public void AddTaskInDefiniteColumn_AddedTask()
        {
            string taskName = "History";
            string taskDescription = "Write a report, learn definitions";
            Task newTask = new Task(taskName, taskDescription, Priority.Middle);
            string boardName = "Activity board";
            Board newBoard = new Board(boardName);
            string firstColumnName = "Studies";
            Column firstColumn = new Column(firstColumnName);
            string secondColumnName = "Home task";
            Column secondColumn = new Column(secondColumnName);

            newBoard.AddColumn(firstColumn);
            newBoard.AddColumn(secondColumn);

            newBoard.AddTaskIntoColumn(newTask, 0);

            Assert.Equal(newTask, firstColumn.LookAllTasks()[0]);
        }

        [Fact]
        public void GetAllColumnFromBoard()
        {
            string boardName = "Activity board";
            Board newBoard = new Board(boardName);
            string firstColumnName = "Studies";
            Column firstColumn = new Column(firstColumnName);
            string secondColumnName = "Home task";
            Column secondColumn = new Column(secondColumnName);
            newBoard.AddColumn(firstColumn);
            newBoard.AddColumn(secondColumn);

            List<Column> listOfColumn = newBoard.LookAllColumn();

            Assert.Equal(new List<Column>() { firstColumn, secondColumn }, listOfColumn);
        }

        [Fact]
        public void TaskTransfer_OnBoard_ColumnWillDelete()
        {
            string taskName = "History";
            string taskDescription = "Write a report, learn definitions";
            Task newTask = new Task(taskName, taskDescription, Priority.Middle);
            string boardName = "Activity board";
            Board newBoard = new Board(boardName);
            string firstColumnName = "Studies";
            Column firstColumn = new Column(firstColumnName);
            string secondColumnName = "Home task";
            Column secondColumn = new Column(secondColumnName);
            newBoard.AddColumn(firstColumn);
            newBoard.AddColumn(secondColumn);
            newBoard.AddTaskIntoColumn(newTask);

            newBoard.MoveTaskBetweenColumns(secondColumn.UnicalID, newTask.UnicalID);

            Assert.Equal(newTask, newBoard.GetColumn(secondColumn.UnicalID).GetTask(newTask.UnicalID));
            Assert.Empty(newBoard.GetColumn(firstColumn.UnicalID).LookAllTasks());
        }

        [Fact]
        public void DeleteTaskOnBoard()
        {
            string taskName = "History";
            string taskDescription = "Write a report, learn definitions";
            Task newTask = new Task(taskName, taskDescription, Priority.Middle);
            string boardName = "Activity board";
            string columnName = "Studies";
            Board newBoard = new Board(boardName);
            Column newcolumn = new Column(columnName);
            newBoard.AddColumn(newcolumn);
            newBoard.AddTaskIntoColumn(newTask);

            newBoard.DeleteTask(newTask.UnicalID);

            Assert.Throws<Exception>(() => newBoard.GetTask(newTask.UnicalID));
        }

        [Fact]
        public void AddTaskInNotExistColumn()
        {
            string taskName = "History";
            string taskDescription = "Write a report, learn definitions";
            Task newTask = new Task(taskName, taskDescription, Priority.Middle);
            string boardName = "Activity board";
            Board newBoard = new Board(boardName);

            Assert.Throws<Exception>(() => newBoard.AddTaskIntoColumn(newTask, 9));
        }

        [Fact]
        public void FindNotExistTask()
        {
            string boardName = "Activity board";
            Board newBoard = new Board(boardName);

            Assert.Throws<Exception>(() => newBoard.GetTask("123"));
        }

        [Fact]
        public void GetNotExistColumn()
        {
            string boardName = "Activity board";
            Board newBoard = new Board(boardName);

            Assert.Throws<Exception>(() => newBoard.GetColumn("123"));
        }

        [Fact]
        public void DeleteNotExistTaskOnBoard()
        {
            string boardName = "Activity board";
            Board newBoard = new Board(boardName);

            Assert.Throws<Exception>(() => newBoard.DeleteTask("123"));
        }

        [Fact]
        public void AddInvalidColumnInBoard()
        {
            string boardName = "Activity board";
            string columnName = "Studies";
            string invalidColumn = "Column number 11";
            Board newBoard = new Board(boardName);
            for (int i = 1; i <= 10; i++)
            {
                newBoard.AddColumn(new Column(columnName + i));
            }

            Assert.Throws<Exception>(() => newBoard.AddColumn(new Column(invalidColumn))
            );
        }

        [Fact]
        public void AddExistColumnInBoard()
        {
            string boardName = "Activity board";
            string columnName = "Studies";
            Board newBoard = new Board(boardName);
            Column newcolumn = new Column(columnName);
            newBoard.AddColumn(newcolumn);

            Assert.Throws<Exception>(() => newBoard.AddColumn(newcolumn));
        }
    }
}