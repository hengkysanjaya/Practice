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

namespace CRUDBindingSource
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="BinaBangsaSchool")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCourse(Course instance);
    partial void UpdateCourse(Course instance);
    partial void DeleteCourse(Course instance);
    partial void InsertStudent(Student instance);
    partial void UpdateStudent(Student instance);
    partial void DeleteStudent(Student instance);
    partial void InsertScore(Score instance);
    partial void UpdateScore(Score instance);
    partial void DeleteScore(Score instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::CRUDBindingSource.Properties.Settings.Default.BinaBangsaSchoolConnectionString, mappingSource)
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
		
		public System.Data.Linq.Table<Course> Courses
		{
			get
			{
				return this.GetTable<Course>();
			}
		}
		
		public System.Data.Linq.Table<Student> Students
		{
			get
			{
				return this.GetTable<Student>();
			}
		}
		
		public System.Data.Linq.Table<Score> Scores
		{
			get
			{
				return this.GetTable<Score>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Course")]
	public partial class Course : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID_Course;
		
		private string _Name;
		
		private double _Assignment;
		
		private double _Mid_Exam;
		
		private double _Final_Exam;
		
		private EntitySet<Score> _Scores;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnID_CourseChanging(int value);
    partial void OnID_CourseChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnAssignmentChanging(double value);
    partial void OnAssignmentChanged();
    partial void OnMid_ExamChanging(double value);
    partial void OnMid_ExamChanged();
    partial void OnFinal_ExamChanging(double value);
    partial void OnFinal_ExamChanged();
    #endregion
		
		public Course()
		{
			this._Scores = new EntitySet<Score>(new Action<Score>(this.attach_Scores), new Action<Score>(this.detach_Scores));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[ID Course]", Storage="_ID_Course", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ID_Course
		{
			get
			{
				return this._ID_Course;
			}
			set
			{
				if ((this._ID_Course != value))
				{
					this.OnID_CourseChanging(value);
					this.SendPropertyChanging();
					this._ID_Course = value;
					this.SendPropertyChanged("ID_Course");
					this.OnID_CourseChanged();
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Assignment", DbType="Float NOT NULL")]
		public double Assignment
		{
			get
			{
				return this._Assignment;
			}
			set
			{
				if ((this._Assignment != value))
				{
					this.OnAssignmentChanging(value);
					this.SendPropertyChanging();
					this._Assignment = value;
					this.SendPropertyChanged("Assignment");
					this.OnAssignmentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Mid Exam]", Storage="_Mid_Exam", DbType="Float NOT NULL")]
		public double Mid_Exam
		{
			get
			{
				return this._Mid_Exam;
			}
			set
			{
				if ((this._Mid_Exam != value))
				{
					this.OnMid_ExamChanging(value);
					this.SendPropertyChanging();
					this._Mid_Exam = value;
					this.SendPropertyChanged("Mid_Exam");
					this.OnMid_ExamChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Final Exam]", Storage="_Final_Exam", DbType="Float NOT NULL")]
		public double Final_Exam
		{
			get
			{
				return this._Final_Exam;
			}
			set
			{
				if ((this._Final_Exam != value))
				{
					this.OnFinal_ExamChanging(value);
					this.SendPropertyChanging();
					this._Final_Exam = value;
					this.SendPropertyChanged("Final_Exam");
					this.OnFinal_ExamChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Course_Score", Storage="_Scores", ThisKey="ID_Course", OtherKey="ID_Course")]
		public EntitySet<Score> Scores
		{
			get
			{
				return this._Scores;
			}
			set
			{
				this._Scores.Assign(value);
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
		
		private void attach_Scores(Score entity)
		{
			this.SendPropertyChanging();
			entity.Course = this;
		}
		
		private void detach_Scores(Score entity)
		{
			this.SendPropertyChanging();
			entity.Course = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Student")]
	public partial class Student : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _NISN;
		
		private string _Name;
		
		private char _Gender;
		
		private string _Birthplace;
		
		private System.DateTime _Date_of_Birth;
		
		private string _Address;
		
		private string _Phone_Number;
		
		private string _Class;
		
		private EntityRef<Student> _Student2;
		
		private EntitySet<Score> _Scores;
		
		private EntityRef<Student> _Student1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnNISNChanging(string value);
    partial void OnNISNChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnGenderChanging(char value);
    partial void OnGenderChanged();
    partial void OnBirthplaceChanging(string value);
    partial void OnBirthplaceChanged();
    partial void OnDate_of_BirthChanging(System.DateTime value);
    partial void OnDate_of_BirthChanged();
    partial void OnAddressChanging(string value);
    partial void OnAddressChanged();
    partial void OnPhone_NumberChanging(string value);
    partial void OnPhone_NumberChanged();
    partial void OnClassChanging(string value);
    partial void OnClassChanged();
    #endregion
		
		public Student()
		{
			this._Student2 = default(EntityRef<Student>);
			this._Scores = new EntitySet<Score>(new Action<Score>(this.attach_Scores), new Action<Score>(this.detach_Scores));
			this._Student1 = default(EntityRef<Student>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NISN", DbType="Char(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string NISN
		{
			get
			{
				return this._NISN;
			}
			set
			{
				if ((this._NISN != value))
				{
					if (this._Student1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnNISNChanging(value);
					this.SendPropertyChanging();
					this._NISN = value;
					this.SendPropertyChanged("NISN");
					this.OnNISNChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Birthplace", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Birthplace
		{
			get
			{
				return this._Birthplace;
			}
			set
			{
				if ((this._Birthplace != value))
				{
					this.OnBirthplaceChanging(value);
					this.SendPropertyChanging();
					this._Birthplace = value;
					this.SendPropertyChanged("Birthplace");
					this.OnBirthplaceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Date of Birth]", Storage="_Date_of_Birth", DbType="Date NOT NULL")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Address", DbType="Text NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Phone Number]", Storage="_Phone_Number", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Class", DbType="Char(2) NOT NULL", CanBeNull=false)]
		public string Class
		{
			get
			{
				return this._Class;
			}
			set
			{
				if ((this._Class != value))
				{
					this.OnClassChanging(value);
					this.SendPropertyChanging();
					this._Class = value;
					this.SendPropertyChanged("Class");
					this.OnClassChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Student_Student", Storage="_Student2", ThisKey="NISN", OtherKey="NISN", IsUnique=true, IsForeignKey=false)]
		public Student Student2
		{
			get
			{
				return this._Student2.Entity;
			}
			set
			{
				Student previousValue = this._Student2.Entity;
				if (((previousValue != value) 
							|| (this._Student2.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Student2.Entity = null;
						previousValue.Student1 = null;
					}
					this._Student2.Entity = value;
					if ((value != null))
					{
						value.Student1 = this;
					}
					this.SendPropertyChanged("Student2");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Student_Score", Storage="_Scores", ThisKey="NISN", OtherKey="NISN")]
		public EntitySet<Score> Scores
		{
			get
			{
				return this._Scores;
			}
			set
			{
				this._Scores.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Student_Student", Storage="_Student1", ThisKey="NISN", OtherKey="NISN", IsForeignKey=true)]
		public Student Student1
		{
			get
			{
				return this._Student1.Entity;
			}
			set
			{
				Student previousValue = this._Student1.Entity;
				if (((previousValue != value) 
							|| (this._Student1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Student1.Entity = null;
						previousValue.Student2 = null;
					}
					this._Student1.Entity = value;
					if ((value != null))
					{
						value.Student2 = this;
						this._NISN = value.NISN;
					}
					else
					{
						this._NISN = default(string);
					}
					this.SendPropertyChanged("Student1");
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
		
		private void attach_Scores(Score entity)
		{
			this.SendPropertyChanging();
			entity.Student = this;
		}
		
		private void detach_Scores(Score entity)
		{
			this.SendPropertyChanging();
			entity.Student = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Score")]
	public partial class Score : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _NISN;
		
		private int _ID_Course;
		
		private int _Assignment;
		
		private int _Mid_Exam;
		
		private int _Final_Exam;
		
		private EntityRef<Course> _Course;
		
		private EntityRef<Student> _Student;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnNISNChanging(string value);
    partial void OnNISNChanged();
    partial void OnID_CourseChanging(int value);
    partial void OnID_CourseChanged();
    partial void OnAssignmentChanging(int value);
    partial void OnAssignmentChanged();
    partial void OnMid_ExamChanging(int value);
    partial void OnMid_ExamChanged();
    partial void OnFinal_ExamChanging(int value);
    partial void OnFinal_ExamChanged();
    #endregion
		
		public Score()
		{
			this._Course = default(EntityRef<Course>);
			this._Student = default(EntityRef<Student>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NISN", DbType="Char(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string NISN
		{
			get
			{
				return this._NISN;
			}
			set
			{
				if ((this._NISN != value))
				{
					if (this._Student.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnNISNChanging(value);
					this.SendPropertyChanging();
					this._NISN = value;
					this.SendPropertyChanged("NISN");
					this.OnNISNChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[ID Course]", Storage="_ID_Course", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ID_Course
		{
			get
			{
				return this._ID_Course;
			}
			set
			{
				if ((this._ID_Course != value))
				{
					this.OnID_CourseChanging(value);
					this.SendPropertyChanging();
					this._ID_Course = value;
					this.SendPropertyChanged("ID_Course");
					this.OnID_CourseChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Assignment", DbType="Int NOT NULL")]
		public int Assignment
		{
			get
			{
				return this._Assignment;
			}
			set
			{
				if ((this._Assignment != value))
				{
					this.OnAssignmentChanging(value);
					this.SendPropertyChanging();
					this._Assignment = value;
					this.SendPropertyChanged("Assignment");
					this.OnAssignmentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Mid Exam]", Storage="_Mid_Exam", DbType="Int NOT NULL")]
		public int Mid_Exam
		{
			get
			{
				return this._Mid_Exam;
			}
			set
			{
				if ((this._Mid_Exam != value))
				{
					this.OnMid_ExamChanging(value);
					this.SendPropertyChanging();
					this._Mid_Exam = value;
					this.SendPropertyChanged("Mid_Exam");
					this.OnMid_ExamChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Final Exam]", Storage="_Final_Exam", DbType="Int NOT NULL")]
		public int Final_Exam
		{
			get
			{
				return this._Final_Exam;
			}
			set
			{
				if ((this._Final_Exam != value))
				{
					this.OnFinal_ExamChanging(value);
					this.SendPropertyChanging();
					this._Final_Exam = value;
					this.SendPropertyChanged("Final_Exam");
					this.OnFinal_ExamChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Course_Score", Storage="_Course", ThisKey="ID_Course", OtherKey="ID_Course", IsForeignKey=true)]
		public Course Course
		{
			get
			{
				return this._Course.Entity;
			}
			set
			{
				Course previousValue = this._Course.Entity;
				if (((previousValue != value) 
							|| (this._Course.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Course.Entity = null;
						previousValue.Scores.Remove(this);
					}
					this._Course.Entity = value;
					if ((value != null))
					{
						value.Scores.Add(this);
						this._ID_Course = value.ID_Course;
					}
					else
					{
						this._ID_Course = default(int);
					}
					this.SendPropertyChanged("Course");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Student_Score", Storage="_Student", ThisKey="NISN", OtherKey="NISN", IsForeignKey=true)]
		public Student Student
		{
			get
			{
				return this._Student.Entity;
			}
			set
			{
				Student previousValue = this._Student.Entity;
				if (((previousValue != value) 
							|| (this._Student.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Student.Entity = null;
						previousValue.Scores.Remove(this);
					}
					this._Student.Entity = value;
					if ((value != null))
					{
						value.Scores.Add(this);
						this._NISN = value.NISN;
					}
					else
					{
						this._NISN = default(string);
					}
					this.SendPropertyChanged("Student");
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
}
#pragma warning restore 1591