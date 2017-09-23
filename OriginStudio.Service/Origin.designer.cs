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

namespace OriginStudio.Service
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Origin")]
	public partial class OriginDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertOR_Form(OR_Form instance);
    partial void UpdateOR_Form(OR_Form instance);
    partial void DeleteOR_Form(OR_Form instance);
    partial void InsertOR_LookupValue(OR_LookupValue instance);
    partial void UpdateOR_LookupValue(OR_LookupValue instance);
    partial void DeleteOR_LookupValue(OR_LookupValue instance);
    partial void InsertOR_Input(OR_Input instance);
    partial void UpdateOR_Input(OR_Input instance);
    partial void DeleteOR_Input(OR_Input instance);
    partial void InsertOR_Item(OR_Item instance);
    partial void UpdateOR_Item(OR_Item instance);
    partial void DeleteOR_Item(OR_Item instance);
    partial void InsertOR_ItemAction(OR_ItemAction instance);
    partial void UpdateOR_ItemAction(OR_ItemAction instance);
    partial void DeleteOR_ItemAction(OR_ItemAction instance);
    partial void InsertOR_ItemType(OR_ItemType instance);
    partial void UpdateOR_ItemType(OR_ItemType instance);
    partial void DeleteOR_ItemType(OR_ItemType instance);
    partial void InsertOR_Lookup(OR_Lookup instance);
    partial void UpdateOR_Lookup(OR_Lookup instance);
    partial void DeleteOR_Lookup(OR_Lookup instance);
    partial void InsertOR_Property(OR_Property instance);
    partial void UpdateOR_Property(OR_Property instance);
    partial void DeleteOR_Property(OR_Property instance);
    #endregion
		
		public OriginDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["OriginConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public OriginDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public OriginDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public OriginDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public OriginDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<OR_Form> OR_Forms
		{
			get
			{
				return this.GetTable<OR_Form>();
			}
		}
		
		public System.Data.Linq.Table<OR_LookupValue> OR_LookupValues
		{
			get
			{
				return this.GetTable<OR_LookupValue>();
			}
		}
		
		public System.Data.Linq.Table<OR_Input> OR_Inputs
		{
			get
			{
				return this.GetTable<OR_Input>();
			}
		}
		
		public System.Data.Linq.Table<OR_Item> OR_Items
		{
			get
			{
				return this.GetTable<OR_Item>();
			}
		}
		
		public System.Data.Linq.Table<OR_ItemAction> OR_ItemActions
		{
			get
			{
				return this.GetTable<OR_ItemAction>();
			}
		}
		
		public System.Data.Linq.Table<OR_ItemType> OR_ItemTypes
		{
			get
			{
				return this.GetTable<OR_ItemType>();
			}
		}
		
		public System.Data.Linq.Table<OR_Lookup> OR_Lookups
		{
			get
			{
				return this.GetTable<OR_Lookup>();
			}
		}
		
		public System.Data.Linq.Table<OR_Property> OR_Properties
		{
			get
			{
				return this.GetTable<OR_Property>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.OR_Form")]
	public partial class OR_Form : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _OriginId;
		
		private string _Name;
		
		private string _Type;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnOriginIdChanging(string value);
    partial void OnOriginIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnTypeChanging(string value);
    partial void OnTypeChanged();
    #endregion
		
		public OR_Form()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OriginId", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string OriginId
		{
			get
			{
				return this._OriginId;
			}
			set
			{
				if ((this._OriginId != value))
				{
					this.OnOriginIdChanging(value);
					this.SendPropertyChanging();
					this._OriginId = value;
					this.SendPropertyChanged("OriginId");
					this.OnOriginIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Type", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				if ((this._Type != value))
				{
					this.OnTypeChanging(value);
					this.SendPropertyChanging();
					this._Type = value;
					this.SendPropertyChanged("Type");
					this.OnTypeChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.OR_LookupValue")]
	public partial class OR_LookupValue : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _OriginId;
		
		private string _RelatedOriginId;
		
		private string _Value;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnOriginIdChanging(string value);
    partial void OnOriginIdChanged();
    partial void OnRelatedOriginIdChanging(string value);
    partial void OnRelatedOriginIdChanged();
    partial void OnValueChanging(string value);
    partial void OnValueChanged();
    #endregion
		
		public OR_LookupValue()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OriginId", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string OriginId
		{
			get
			{
				return this._OriginId;
			}
			set
			{
				if ((this._OriginId != value))
				{
					this.OnOriginIdChanging(value);
					this.SendPropertyChanging();
					this._OriginId = value;
					this.SendPropertyChanged("OriginId");
					this.OnOriginIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RelatedOriginId", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string RelatedOriginId
		{
			get
			{
				return this._RelatedOriginId;
			}
			set
			{
				if ((this._RelatedOriginId != value))
				{
					this.OnRelatedOriginIdChanging(value);
					this.SendPropertyChanging();
					this._RelatedOriginId = value;
					this.SendPropertyChanged("RelatedOriginId");
					this.OnRelatedOriginIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Value", DbType="Text NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				if ((this._Value != value))
				{
					this.OnValueChanging(value);
					this.SendPropertyChanging();
					this._Value = value;
					this.SendPropertyChanged("Value");
					this.OnValueChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.OR_Input")]
	public partial class OR_Input : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _OriginId;
		
		private string _RelatedOriginId;
		
		private string _Name;
		
		private string _Type;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnOriginIdChanging(string value);
    partial void OnOriginIdChanged();
    partial void OnRelatedOriginIdChanging(string value);
    partial void OnRelatedOriginIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnTypeChanging(string value);
    partial void OnTypeChanged();
    #endregion
		
		public OR_Input()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OriginId", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string OriginId
		{
			get
			{
				return this._OriginId;
			}
			set
			{
				if ((this._OriginId != value))
				{
					this.OnOriginIdChanging(value);
					this.SendPropertyChanging();
					this._OriginId = value;
					this.SendPropertyChanged("OriginId");
					this.OnOriginIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RelatedOriginId", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string RelatedOriginId
		{
			get
			{
				return this._RelatedOriginId;
			}
			set
			{
				if ((this._RelatedOriginId != value))
				{
					this.OnRelatedOriginIdChanging(value);
					this.SendPropertyChanging();
					this._RelatedOriginId = value;
					this.SendPropertyChanged("RelatedOriginId");
					this.OnRelatedOriginIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Type", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				if ((this._Type != value))
				{
					this.OnTypeChanging(value);
					this.SendPropertyChanging();
					this._Type = value;
					this.SendPropertyChanged("Type");
					this.OnTypeChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.OR_Item")]
	public partial class OR_Item : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _OriginId;
		
		private string _ItemTypeOriginId;
		
		private System.DateTime _CreationDate;
		
		private System.DateTime _LastEditDate;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnOriginIdChanging(string value);
    partial void OnOriginIdChanged();
    partial void OnItemTypeOriginIdChanging(string value);
    partial void OnItemTypeOriginIdChanged();
    partial void OnCreationDateChanging(System.DateTime value);
    partial void OnCreationDateChanged();
    partial void OnLastEditDateChanging(System.DateTime value);
    partial void OnLastEditDateChanged();
    #endregion
		
		public OR_Item()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OriginId", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string OriginId
		{
			get
			{
				return this._OriginId;
			}
			set
			{
				if ((this._OriginId != value))
				{
					this.OnOriginIdChanging(value);
					this.SendPropertyChanging();
					this._OriginId = value;
					this.SendPropertyChanged("OriginId");
					this.OnOriginIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ItemTypeOriginId", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string ItemTypeOriginId
		{
			get
			{
				return this._ItemTypeOriginId;
			}
			set
			{
				if ((this._ItemTypeOriginId != value))
				{
					this.OnItemTypeOriginIdChanging(value);
					this.SendPropertyChanging();
					this._ItemTypeOriginId = value;
					this.SendPropertyChanged("ItemTypeOriginId");
					this.OnItemTypeOriginIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreationDate", DbType="DateTime NOT NULL")]
		public System.DateTime CreationDate
		{
			get
			{
				return this._CreationDate;
			}
			set
			{
				if ((this._CreationDate != value))
				{
					this.OnCreationDateChanging(value);
					this.SendPropertyChanging();
					this._CreationDate = value;
					this.SendPropertyChanged("CreationDate");
					this.OnCreationDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastEditDate", DbType="DateTime NOT NULL")]
		public System.DateTime LastEditDate
		{
			get
			{
				return this._LastEditDate;
			}
			set
			{
				if ((this._LastEditDate != value))
				{
					this.OnLastEditDateChanging(value);
					this.SendPropertyChanging();
					this._LastEditDate = value;
					this.SendPropertyChanged("LastEditDate");
					this.OnLastEditDateChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.OR_ItemAction")]
	public partial class OR_ItemAction : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _OriginId;
		
		private string _Name;
		
		private string _FormOriginId;
		
		private string _ItemTypeOriginId;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnOriginIdChanging(string value);
    partial void OnOriginIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnFormOriginIdChanging(string value);
    partial void OnFormOriginIdChanged();
    partial void OnItemTypeOriginIdChanging(string value);
    partial void OnItemTypeOriginIdChanged();
    #endregion
		
		public OR_ItemAction()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OriginId", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string OriginId
		{
			get
			{
				return this._OriginId;
			}
			set
			{
				if ((this._OriginId != value))
				{
					this.OnOriginIdChanging(value);
					this.SendPropertyChanging();
					this._OriginId = value;
					this.SendPropertyChanged("OriginId");
					this.OnOriginIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FormOriginId", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string FormOriginId
		{
			get
			{
				return this._FormOriginId;
			}
			set
			{
				if ((this._FormOriginId != value))
				{
					this.OnFormOriginIdChanging(value);
					this.SendPropertyChanging();
					this._FormOriginId = value;
					this.SendPropertyChanged("FormOriginId");
					this.OnFormOriginIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ItemTypeOriginId", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string ItemTypeOriginId
		{
			get
			{
				return this._ItemTypeOriginId;
			}
			set
			{
				if ((this._ItemTypeOriginId != value))
				{
					this.OnItemTypeOriginIdChanging(value);
					this.SendPropertyChanging();
					this._ItemTypeOriginId = value;
					this.SendPropertyChanged("ItemTypeOriginId");
					this.OnItemTypeOriginIdChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.OR_ItemType")]
	public partial class OR_ItemType : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _OriginId;
		
		private string _Name;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnOriginIdChanging(string value);
    partial void OnOriginIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    #endregion
		
		public OR_ItemType()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OriginId", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string OriginId
		{
			get
			{
				return this._OriginId;
			}
			set
			{
				if ((this._OriginId != value))
				{
					this.OnOriginIdChanging(value);
					this.SendPropertyChanging();
					this._OriginId = value;
					this.SendPropertyChanged("OriginId");
					this.OnOriginIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.OR_Lookup")]
	public partial class OR_Lookup : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _OriginId;
		
		private string _Name;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnOriginIdChanging(string value);
    partial void OnOriginIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    #endregion
		
		public OR_Lookup()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OriginId", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string OriginId
		{
			get
			{
				return this._OriginId;
			}
			set
			{
				if ((this._OriginId != value))
				{
					this.OnOriginIdChanging(value);
					this.SendPropertyChanging();
					this._OriginId = value;
					this.SendPropertyChanged("OriginId");
					this.OnOriginIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.OR_Property")]
	public partial class OR_Property : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _OriginId;
		
		private string _RelatedOriginId;
		
		private string _Name;
		
		private string _Value;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnOriginIdChanging(string value);
    partial void OnOriginIdChanged();
    partial void OnRelatedOriginIdChanging(string value);
    partial void OnRelatedOriginIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnValueChanging(string value);
    partial void OnValueChanged();
    #endregion
		
		public OR_Property()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OriginId", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string OriginId
		{
			get
			{
				return this._OriginId;
			}
			set
			{
				if ((this._OriginId != value))
				{
					this.OnOriginIdChanging(value);
					this.SendPropertyChanging();
					this._OriginId = value;
					this.SendPropertyChanged("OriginId");
					this.OnOriginIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RelatedOriginId", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string RelatedOriginId
		{
			get
			{
				return this._RelatedOriginId;
			}
			set
			{
				if ((this._RelatedOriginId != value))
				{
					this.OnRelatedOriginIdChanging(value);
					this.SendPropertyChanging();
					this._RelatedOriginId = value;
					this.SendPropertyChanged("RelatedOriginId");
					this.OnRelatedOriginIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Value", DbType="Text NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				if ((this._Value != value))
				{
					this.OnValueChanging(value);
					this.SendPropertyChanging();
					this._Value = value;
					this.SendPropertyChanged("Value");
					this.OnValueChanged();
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
