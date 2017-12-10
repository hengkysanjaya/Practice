﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChartSeleknas_Review
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="module03_19")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCategory(Category instance);
    partial void UpdateCategory(Category instance);
    partial void DeleteCategory(Category instance);
    partial void InsertProduct(Product instance);
    partial void UpdateProduct(Product instance);
    partial void DeleteProduct(Product instance);
    partial void InsertDetailTransaction(DetailTransaction instance);
    partial void UpdateDetailTransaction(DetailTransaction instance);
    partial void DeleteDetailTransaction(DetailTransaction instance);
    partial void InsertEmployee(Employee instance);
    partial void UpdateEmployee(Employee instance);
    partial void DeleteEmployee(Employee instance);
    partial void InsertHeaderTransaction(HeaderTransaction instance);
    partial void UpdateHeaderTransaction(HeaderTransaction instance);
    partial void DeleteHeaderTransaction(HeaderTransaction instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::ChartSeleknas_Review.Properties.Settings.Default.module03_19ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Category> Categories
		{
			get
			{
				return this.GetTable<Category>();
			}
		}
		
		public System.Data.Linq.Table<Product> Products
		{
			get
			{
				return this.GetTable<Product>();
			}
		}
		
		public System.Data.Linq.Table<DetailTransaction> DetailTransactions
		{
			get
			{
				return this.GetTable<DetailTransaction>();
			}
		}
		
		public System.Data.Linq.Table<Employee> Employees
		{
			get
			{
				return this.GetTable<Employee>();
			}
		}
		
		public System.Data.Linq.Table<HeaderTransaction> HeaderTransactions
		{
			get
			{
				return this.GetTable<HeaderTransaction>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Category")]
	public partial class Category : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Name;
		
		private EntitySet<Product> _Products;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    #endregion
		
		public Category()
		{
			this._Products = new EntitySet<Product>(new Action<Product>(this.attach_Products), new Action<Product>(this.detach_Products));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Category_Product", Storage="_Products", ThisKey="ID", OtherKey="ID_Category")]
		public EntitySet<Product> Products
		{
			get
			{
				return this._Products;
			}
			set
			{
				this._Products.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Products(Product entity)
		{
			this.SendPropertyChanging();
			entity.Category = this;
		}
		
		private void detach_Products(Product entity)
		{
			this.SendPropertyChanging();
			entity.Category = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Product")]
	public partial class Product : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Name;
		
		private int _ID_Category;
		
		private int _Price_Customer;
		
		private int _Price_Sales;
		
		private EntitySet<DetailTransaction> _DetailTransactions;
		
		private EntityRef<Category> _Category;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnID_CategoryChanging(int value);
    partial void OnID_CategoryChanged();
    partial void OnPrice_CustomerChanging(int value);
    partial void OnPrice_CustomerChanged();
    partial void OnPrice_SalesChanging(int value);
    partial void OnPrice_SalesChanged();
    #endregion
		
		public Product()
		{
			this._DetailTransactions = new EntitySet<DetailTransaction>(new Action<DetailTransaction>(this.attach_DetailTransactions), new Action<DetailTransaction>(this.detach_DetailTransactions));
			this._Category = default(EntityRef<Category>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[ID Category]", Storage="_ID_Category", DbType="Int NOT NULL")]
		public int ID_Category
		{
			get
			{
				return this._ID_Category;
			}
			set
			{
				if ((this._ID_Category != value))
				{
					this.OnID_CategoryChanging(value);
					this.SendPropertyChanging();
					this._ID_Category = value;
					this.SendPropertyChanged("ID_Category");
					this.OnID_CategoryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Price Customer]", Storage="_Price_Customer", DbType="Int NOT NULL")]
		public int Price_Customer
		{
			get
			{
				return this._Price_Customer;
			}
			set
			{
				if ((this._Price_Customer != value))
				{
					this.OnPrice_CustomerChanging(value);
					this.SendPropertyChanging();
					this._Price_Customer = value;
					this.SendPropertyChanged("Price_Customer");
					this.OnPrice_CustomerChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Price Sales]", Storage="_Price_Sales", DbType="Int NOT NULL")]
		public int Price_Sales
		{
			get
			{
				return this._Price_Sales;
			}
			set
			{
				if ((this._Price_Sales != value))
				{
					this.OnPrice_SalesChanging(value);
					this.SendPropertyChanging();
					this._Price_Sales = value;
					this.SendPropertyChanged("Price_Sales");
					this.OnPrice_SalesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Product_DetailTransaction", Storage="_DetailTransactions", ThisKey="ID", OtherKey="ID_Product")]
		public EntitySet<DetailTransaction> DetailTransactions
		{
			get
			{
				return this._DetailTransactions;
			}
			set
			{
				this._DetailTransactions.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Category_Product", Storage="_Category", ThisKey="ID_Category", OtherKey="ID", IsForeignKey=true)]
		public Category Category
		{
			get
			{
				return this._Category.Entity;
			}
			set
			{
				Category previousValue = this._Category.Entity;
				if (((previousValue != value) 
							|| (this._Category.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Category.Entity = null;
						previousValue.Products.Remove(this);
					}
					this._Category.Entity = value;
					if ((value != null))
					{
						value.Products.Add(this);
						this._ID_Category = value.ID;
					}
					else
					{
						this._ID_Category = default(int);
					}
					this.SendPropertyChanged("Category");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_DetailTransactions(DetailTransaction entity)
		{
			this.SendPropertyChanging();
			entity.Product = this;
		}
		
		private void detach_DetailTransactions(DetailTransaction entity)
		{
			this.SendPropertyChanging();
			entity.Product = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.DetailTransaction")]
	public partial class DetailTransaction : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID_Transaction;
		
		private int _ID_Product;
		
		private int _Quantity;
		
		private EntityRef<Product> _Product;
		
		private EntityRef<HeaderTransaction> _HeaderTransaction;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnID_TransactionChanging(int value);
    partial void OnID_TransactionChanged();
    partial void OnID_ProductChanging(int value);
    partial void OnID_ProductChanged();
    partial void OnQuantityChanging(int value);
    partial void OnQuantityChanged();
    #endregion
		
		public DetailTransaction()
		{
			this._Product = default(EntityRef<Product>);
			this._HeaderTransaction = default(EntityRef<HeaderTransaction>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[ID Transaction]", Storage="_ID_Transaction", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ID_Transaction
		{
			get
			{
				return this._ID_Transaction;
			}
			set
			{
				if ((this._ID_Transaction != value))
				{
					this.OnID_TransactionChanging(value);
					this.SendPropertyChanging();
					this._ID_Transaction = value;
					this.SendPropertyChanged("ID_Transaction");
					this.OnID_TransactionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[ID Product]", Storage="_ID_Product", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ID_Product
		{
			get
			{
				return this._ID_Product;
			}
			set
			{
				if ((this._ID_Product != value))
				{
					this.OnID_ProductChanging(value);
					this.SendPropertyChanging();
					this._ID_Product = value;
					this.SendPropertyChanged("ID_Product");
					this.OnID_ProductChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Quantity", DbType="Int NOT NULL")]
		public int Quantity
		{
			get
			{
				return this._Quantity;
			}
			set
			{
				if ((this._Quantity != value))
				{
					this.OnQuantityChanging(value);
					this.SendPropertyChanging();
					this._Quantity = value;
					this.SendPropertyChanged("Quantity");
					this.OnQuantityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Product_DetailTransaction", Storage="_Product", ThisKey="ID_Product", OtherKey="ID", IsForeignKey=true)]
		public Product Product
		{
			get
			{
				return this._Product.Entity;
			}
			set
			{
				Product previousValue = this._Product.Entity;
				if (((previousValue != value) 
							|| (this._Product.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Product.Entity = null;
						previousValue.DetailTransactions.Remove(this);
					}
					this._Product.Entity = value;
					if ((value != null))
					{
						value.DetailTransactions.Add(this);
						this._ID_Product = value.ID;
					}
					else
					{
						this._ID_Product = default(int);
					}
					this.SendPropertyChanged("Product");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="HeaderTransaction_DetailTransaction", Storage="_HeaderTransaction", ThisKey="ID_Transaction", OtherKey="ID", IsForeignKey=true)]
		public HeaderTransaction HeaderTransaction
		{
			get
			{
				return this._HeaderTransaction.Entity;
			}
			set
			{
				HeaderTransaction previousValue = this._HeaderTransaction.Entity;
				if (((previousValue != value) 
							|| (this._HeaderTransaction.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._HeaderTransaction.Entity = null;
						previousValue.DetailTransactions.Remove(this);
					}
					this._HeaderTransaction.Entity = value;
					if ((value != null))
					{
						value.DetailTransactions.Add(this);
						this._ID_Transaction = value.ID;
					}
					else
					{
						this._ID_Transaction = default(int);
					}
					this.SendPropertyChanged("HeaderTransaction");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Employee")]
	public partial class Employee : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _ID;
		
		private string _Name;
		
		private string _Password;
		
		private System.DateTime _Date_of_Birth;
		
		private char _Gender;
		
		private string _Phone_Number;
		
		private string _Address;
		
		private string _Status;
		
		private string _ID_Leader;
		
		private EntitySet<Employee> _Employees;
		
		private EntitySet<HeaderTransaction> _HeaderTransactions;
		
		private EntityRef<Employee> _Employee1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(string value);
    partial void OnIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnDate_of_BirthChanging(System.DateTime value);
    partial void OnDate_of_BirthChanged();
    partial void OnGenderChanging(char value);
    partial void OnGenderChanged();
    partial void OnPhone_NumberChanging(string value);
    partial void OnPhone_NumberChanged();
    partial void OnAddressChanging(string value);
    partial void OnAddressChanged();
    partial void OnStatusChanging(string value);
    partial void OnStatusChanged();
    partial void OnID_LeaderChanging(string value);
    partial void OnID_LeaderChanged();
    #endregion
		
		public Employee()
		{
			this._Employees = new EntitySet<Employee>(new Action<Employee>(this.attach_Employees), new Action<Employee>(this.detach_Employees));
			this._HeaderTransactions = new EntitySet<HeaderTransaction>(new Action<HeaderTransaction>(this.attach_HeaderTransactions), new Action<HeaderTransaction>(this.detach_HeaderTransactions));
			this._Employee1 = default(EntityRef<Employee>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Char(5) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Date of Birth]", Storage="_Date_of_Birth", DbType="DateTime NOT NULL")]
		public System.DateTime Date_of_Birth
		{
			get
			{
				return this._Date_of_Birth;
			}
			set
			{
				if ((this._Date_of_Birth != value))
				{
					this.OnDate_of_BirthChanging(value);
					this.SendPropertyChanging();
					this._Date_of_Birth = value;
					this.SendPropertyChanged("Date_of_Birth");
					this.OnDate_of_BirthChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Gender", DbType="Char(1) NOT NULL")]
		public char Gender
		{
			get
			{
				return this._Gender;
			}
			set
			{
				if ((this._Gender != value))
				{
					this.OnGenderChanging(value);
					this.SendPropertyChanging();
					this._Gender = value;
					this.SendPropertyChanged("Gender");
					this.OnGenderChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Phone Number]", Storage="_Phone_Number", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string Phone_Number
		{
			get
			{
				return this._Phone_Number;
			}
			set
			{
				if ((this._Phone_Number != value))
				{
					this.OnPhone_NumberChanging(value);
					this.SendPropertyChanging();
					this._Phone_Number = value;
					this.SendPropertyChanged("Phone_Number");
					this.OnPhone_NumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Address", DbType="NText NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Address
		{
			get
			{
				return this._Address;
			}
			set
			{
				if ((this._Address != value))
				{
					this.OnAddressChanging(value);
					this.SendPropertyChanging();
					this._Address = value;
					this.SendPropertyChanged("Address");
					this.OnAddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this.OnStatusChanging(value);
					this.SendPropertyChanging();
					this._Status = value;
					this.SendPropertyChanged("Status");
					this.OnStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[ID Leader]", Storage="_ID_Leader", DbType="Char(5)")]
		public string ID_Leader
		{
			get
			{
				return this._ID_Leader;
			}
			set
			{
				if ((this._ID_Leader != value))
				{
					this.OnID_LeaderChanging(value);
					this.SendPropertyChanging();
					this._ID_Leader = value;
					this.SendPropertyChanged("ID_Leader");
					this.OnID_LeaderChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Employee_Employee", Storage="_Employees", ThisKey="ID", OtherKey="ID_Leader")]
		public EntitySet<Employee> Employees
		{
			get
			{
				return this._Employees;
			}
			set
			{
				this._Employees.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Employee_HeaderTransaction", Storage="_HeaderTransactions", ThisKey="ID", OtherKey="ID_Employee")]
		public EntitySet<HeaderTransaction> HeaderTransactions
		{
			get
			{
				return this._HeaderTransactions;
			}
			set
			{
				this._HeaderTransactions.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Employee_Employee", Storage="_Employee1", ThisKey="ID_Leader", OtherKey="ID", IsForeignKey=true)]
		public Employee Employee1
		{
			get
			{
				return this._Employee1.Entity;
			}
			set
			{
				Employee previousValue = this._Employee1.Entity;
				if (((previousValue != value) 
							|| (this._Employee1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Employee1.Entity = null;
						previousValue.Employees.Remove(this);
					}
					this._Employee1.Entity = value;
					if ((value != null))
					{
						value.Employees.Add(this);
						this._ID_Leader = value.ID;
					}
					else
					{
						this._ID_Leader = default(string);
					}
					this.SendPropertyChanged("Employee1");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Employees(Employee entity)
		{
			this.SendPropertyChanging();
			entity.Employee1 = this;
		}
		
		private void detach_Employees(Employee entity)
		{
			this.SendPropertyChanging();
			entity.Employee1 = null;
		}
		
		private void attach_HeaderTransactions(HeaderTransaction entity)
		{
			this.SendPropertyChanging();
			entity.Employee = this;
		}
		
		private void detach_HeaderTransactions(HeaderTransaction entity)
		{
			this.SendPropertyChanging();
			entity.Employee = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.HeaderTransaction")]
	public partial class HeaderTransaction : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _ID_Employee;
		
		private System.DateTime _Time;
		
		private EntitySet<DetailTransaction> _DetailTransactions;
		
		private EntityRef<Employee> _Employee;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnID_EmployeeChanging(string value);
    partial void OnID_EmployeeChanged();
    partial void OnTimeChanging(System.DateTime value);
    partial void OnTimeChanged();
    #endregion
		
		public HeaderTransaction()
		{
			this._DetailTransactions = new EntitySet<DetailTransaction>(new Action<DetailTransaction>(this.attach_DetailTransactions), new Action<DetailTransaction>(this.detach_DetailTransactions));
			this._Employee = default(EntityRef<Employee>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[ID Employee]", Storage="_ID_Employee", DbType="Char(5) NOT NULL", CanBeNull=false)]
		public string ID_Employee
		{
			get
			{
				return this._ID_Employee;
			}
			set
			{
				if ((this._ID_Employee != value))
				{
					this.OnID_EmployeeChanging(value);
					this.SendPropertyChanging();
					this._ID_Employee = value;
					this.SendPropertyChanged("ID_Employee");
					this.OnID_EmployeeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Time", DbType="DateTime NOT NULL")]
		public System.DateTime Time
		{
			get
			{
				return this._Time;
			}
			set
			{
				if ((this._Time != value))
				{
					this.OnTimeChanging(value);
					this.SendPropertyChanging();
					this._Time = value;
					this.SendPropertyChanged("Time");
					this.OnTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="HeaderTransaction_DetailTransaction", Storage="_DetailTransactions", ThisKey="ID", OtherKey="ID_Transaction")]
		public EntitySet<DetailTransaction> DetailTransactions
		{
			get
			{
				return this._DetailTransactions;
			}
			set
			{
				this._DetailTransactions.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Employee_HeaderTransaction", Storage="_Employee", ThisKey="ID_Employee", OtherKey="ID", IsForeignKey=true)]
		public Employee Employee
		{
			get
			{
				return this._Employee.Entity;
			}
			set
			{
				Employee previousValue = this._Employee.Entity;
				if (((previousValue != value) 
							|| (this._Employee.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Employee.Entity = null;
						previousValue.HeaderTransactions.Remove(this);
					}
					this._Employee.Entity = value;
					if ((value != null))
					{
						value.HeaderTransactions.Add(this);
						this._ID_Employee = value.ID;
					}
					else
					{
						this._ID_Employee = default(string);
					}
					this.SendPropertyChanged("Employee");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_DetailTransactions(DetailTransaction entity)
		{
			this.SendPropertyChanging();
			entity.HeaderTransaction = this;
		}
		
		private void detach_DetailTransactions(DetailTransaction entity)
		{
			this.SendPropertyChanging();
			entity.HeaderTransaction = null;
		}
	}
}
#pragma warning restore 1591
