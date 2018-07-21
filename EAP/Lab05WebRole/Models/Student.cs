using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab05WebRole.Models
{
    public class Student : TableEntity
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Address { get; set; }
    }

    public class StudentContext
    {
        CloudTable cloudTable = null;

        public StudentContext()
        {
            //CloudStorageAccount csa = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StudentConnectionString"));
            CloudStorageAccount csa = CloudStorageAccount.DevelopmentStorageAccount;

            CloudTableClient tableClient = csa.CreateCloudTableClient();
            cloudTable = tableClient.GetTableReference("Students");
            cloudTable.CreateIfNotExists();
        }

        public IEnumerable<Student> GetStudents()
        {
            return cloudTable.ExecuteQuery(new TableQuery<Student>());
        }

        public void AddStudent(Student newStudent)
        {
            TableOperation tableOperator = TableOperation.Insert(newStudent);
            cloudTable.Execute(tableOperator);
        }

        public void DeleteStudent(string partKey, string rowKey)
        {
            TableOperation retrieveOperation = TableOperation.Retrieve<Student>(partKey, rowKey);
            TableResult retrievedResult = cloudTable.Execute(retrieveOperation);
            var std = (Student)retrievedResult.Result;
            TableOperation tableOperator = TableOperation.Delete(std);
            cloudTable.Execute(tableOperator);
        }

        public Student DetailsStudent(string partKey, string rowKey)
        {
            TableOperation retrieveOperation = TableOperation.Retrieve<Student>(partKey, rowKey);
            TableResult retrievedResult = cloudTable.Execute(retrieveOperation);
            var std = (Student)retrievedResult.Result;
            return std;
        }

        public void EditStudent(Student editStudent)
        {
            TableOperation tableOperator = TableOperation.Replace(editStudent);
            cloudTable.Execute(tableOperator);
        }
    }
}