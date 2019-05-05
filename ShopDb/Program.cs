using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDb
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Создание базы данных
            DataSet shopDB = new DataSet("ShopDB");

            // 2. Таблицы БД
            DataTable products = new DataTable("Products");
            DataTable customers = new DataTable("Customers");
            DataTable employees = new DataTable("Employees");
            DataTable orders = new DataTable("Orders");
            DataTable orderDetails = new DataTable("OrderDetails");


            // 2. Колонки
            InitProductsTable(ref products);
            InitCustomersTable(ref customers);
            InitEmployeesTable(ref employees);
            InitOrdersTable(ref orders);
            InitOrderDetailsTable(ref orderDetails);

            ForeignKeyConstraint FK_Product = new ForeignKeyConstraint(products.Columns["Id"], orderDetails.Columns["ProductId"]);
            orderDetails.Constraints.Add(FK_Product);
            ForeignKeyConstraint FK_Customer = new ForeignKeyConstraint(customers.Columns["Id"], orders.Columns["CustomerId"]);
            orders.Constraints.Add(FK_Customer);
            ForeignKeyConstraint FK_Employee = new ForeignKeyConstraint(employees.Columns["Id"], orders.Columns["EmployeeId"]);
            orders.Constraints.Add(FK_Employee);
            ForeignKeyConstraint FK_Order = new ForeignKeyConstraint(orders.Columns["Id"], orderDetails.Columns["OrderId"]);
            orderDetails.Constraints.Add(FK_Order);

            shopDB.Tables.AddRange(new DataTable[] {
                products,
                customers,
                employees,
                orders,
                orderDetails
            });

            Console.WriteLine("База данных ShopDb создана!");
            Console.ReadLine();

        }

        private static void InitProductsTable(ref DataTable products)
        {
            DataColumn id = new DataColumn("Id", typeof(int));
            id.AllowDBNull = false;
            id.AutoIncrement = true;
            id.AutoIncrementSeed = 1;
            id.AutoIncrementStep = 1;
            id.Caption = "Идентификатор";
            id.Unique = true;
            id.ReadOnly = true;

            DataColumn name = new DataColumn("Name", typeof(string));
            name.Caption = "Наименование";
            name.MaxLength = 100;
            name.AllowDBNull = false;

            DataColumn price = new DataColumn("Price", typeof(float));
            price.Caption = "Цена";
            price.AllowDBNull = false;

            products.Columns.AddRange(new DataColumn[]
            {
                id,
                name,
                price
            });

            products.PrimaryKey = new DataColumn[] { products.Columns["id"] };

        }
        private static void InitCustomersTable(ref DataTable customers)
        {
            DataColumn id = new DataColumn("Id", typeof(int));
            id.AllowDBNull = false;
            id.AutoIncrement = true;
            id.AutoIncrementSeed = 1;
            id.AutoIncrementStep = 1;
            id.Caption = "Идентификатор";
            id.Unique = true;
            id.ReadOnly = true;

            DataColumn name = new DataColumn("Name", typeof(string));
            name.Caption = "Наименование";
            name.MaxLength = 100;
            name.AllowDBNull = false;

            customers.Columns.AddRange(new DataColumn[]
            {
                id,
                name
            });

            customers.PrimaryKey = new DataColumn[] { customers.Columns["id"] };

        }
        private static void InitEmployeesTable(ref DataTable employees)
        {
            DataColumn id = new DataColumn("Id", typeof(int));
            id.AllowDBNull = false;
            id.AutoIncrement = true;
            id.AutoIncrementSeed = 1;
            id.AutoIncrementStep = 1;
            id.Caption = "Идентификатор";
            id.Unique = true;
            id.ReadOnly = true;

            DataColumn name = new DataColumn("Name", typeof(string));
            name.Caption = "Наименование";
            name.MaxLength = 100;
            name.AllowDBNull = false;

            employees.Columns.AddRange(new DataColumn[]
            {
                id,
                name
            });

            employees.PrimaryKey = new DataColumn[] { employees.Columns["id"] };

        }
        private static void InitOrdersTable(ref DataTable orders)
        {
            DataColumn id = new DataColumn("Id", typeof(int));
            id.AllowDBNull = false;
            id.AutoIncrement = true;
            id.AutoIncrementSeed = 1;
            id.AutoIncrementStep = 1;
            id.Caption = "Идентификатор";
            id.Unique = true;
            id.ReadOnly = true;

            DataColumn number = new DataColumn("Number", typeof(int));
            number.Caption = "Номер";
            number.AllowDBNull = false;

            DataColumn date = new DataColumn("Date", typeof(DateTime));
            date.Caption = "Дата";
            date.AllowDBNull = false;

            DataColumn customerId = new DataColumn("CustomerId", typeof(int));
            customerId.Caption = "Код клиента";
            customerId.AllowDBNull = false;

            DataColumn employeeId = new DataColumn("EmployeeId", typeof(int));
            employeeId.Caption = "Код сотрудника";
            employeeId.AllowDBNull = false;
            
            orders.Columns.AddRange(new DataColumn[]
            {
                id,
                number,
                date,
                customerId,
                employeeId
            });

            orders.PrimaryKey = new DataColumn[] { orders.Columns["id"] };

        }
        private static void InitOrderDetailsTable(ref DataTable orderDetails)
        {
            DataColumn id = new DataColumn("Id", typeof(int));
            id.AllowDBNull = false;
            id.AutoIncrement = true;
            id.AutoIncrementSeed = 1;
            id.AutoIncrementStep = 1;
            id.Caption = "Идентификатор";
            id.Unique = true;
            id.ReadOnly = true;

            DataColumn orderId = new DataColumn("OrderId", typeof(int));
            orderId.Caption = "Номер";
            orderId.AllowDBNull = false;

            DataColumn productId = new DataColumn("ProductId", typeof(int));
            productId.Caption = "Код продукта";
            productId.AllowDBNull = false;

            DataColumn count = new DataColumn("Count", typeof(int));
            count.Caption = "Количество";
            count.AllowDBNull = false;

            DataColumn sum = new DataColumn("Sum", typeof(float));
            sum.Caption = "Сумма";
            sum.AllowDBNull = false;

            orderDetails.Columns.AddRange(new DataColumn[]
            {
                id,
                orderId,
                productId,
                count,
                sum
            });

            orderDetails.PrimaryKey = new DataColumn[] { orderDetails.Columns["id"] };

        }
    }
}
