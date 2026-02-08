CREATE TABLE [currency] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [code] char(3) NOT NULL,
  [name] nvarchar(50) NOT NULL,
  [created_at] datetime NOT NULL,
  [updated_at] datetime NOT NULL
)
GO

CREATE TABLE [subscription_type] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [name] nvarchar(100) NOT NULL,
  [fee_base] decimal(18,2) NOT NULL,
  [is_active] bit NOT NULL DEFAULT (1),
  [created_at] datetime NOT NULL,
  [updated_at] datetime NOT NULL
)
GO

CREATE TABLE [tenant] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [currency_id] int NOT NULL,
  [name] nvarchar(200) NOT NULL,
  [is_active] bit NOT NULL DEFAULT (1),
  [created_at] datetime NOT NULL,
  [updated_at] datetime NOT NULL
)
GO

CREATE TABLE [tenant_subscription] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [tenant_id] int NOT NULL,
  [subscription_type_id] int NOT NULL,
  [subscription_currency_id] int NOT NULL,
  [price_charged] decimal(18,2) NOT NULL,
  [start_date] date NOT NULL,
  [end_date] date,
  [is_active] bit NOT NULL DEFAULT (1),
  [created_at] datetime NOT NULL,
  [updated_at] datetime NOT NULL
)
GO

CREATE TABLE [country] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [iso_code] char(2) NOT NULL,
  [name] nvarchar(100) NOT NULL,
  [created_at] datetime NOT NULL,
  [updated_at] datetime NOT NULL
)
GO

CREATE TABLE [company] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [country_id] int NOT NULL,
  [tenant_id] int NOT NULL,
  [name] nvarchar(200) NOT NULL,
  [distinctive_title] nvarchar(250) NOT NULL,
  [vat_number] nvarchar(20) NOT NULL,
  [city] nvarchar(100) NOT NULL,
  [address] nvarchar(250) NOT NULL,
  [zip_code] nvarchar(20) NOT NULL,
  [is_active] bit NOT NULL DEFAULT (1),
  [created_at] datetime NOT NULL,
  [updated_at] datetime NOT NULL
)
GO

CREATE TABLE [tenant_user] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [tenant_id] int NOT NULL,
  [full_name] nvarchar(100) NOT NULL,
  [email] nvarchar(254) NOT NULL,
  [password_hash] nvarchar(200) NOT NULL,
  [is_admin] bit NOT NULL,
  [is_active] bit NOT NULL DEFAULT (1),
  [created_at] datetime NOT NULL,
  [updated_at] datetime NOT NULL
)
GO

CREATE TABLE [tenant_user_access] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [tenant_user_id] int NOT NULL,
  [company_id] int NOT NULL,
  [has_write_access] bit NOT NULL DEFAULT (0),
  [is_active] bit NOT NULL DEFAULT (1),
  [created_at] datetime NOT NULL,
  [updated_at] datetime NOT NULL
)
GO

CREATE TABLE [packaging_type] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [company_id] int NOT NULL,
  [name] nvarchar(200) NOT NULL,
  [is_active] bit NOT NULL DEFAULT (1),
  [created_at] datetime NOT NULL,
  [updated_at] datetime NOT NULL
)
GO

CREATE TABLE [product_category] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [company_id] int NOT NULL,
  [name] nvarchar(200) NOT NULL,
  [is_active] bit NOT NULL DEFAULT (1),
  [created_at] datetime NOT NULL,
  [updated_at] datetime NOT NULL
)
GO

CREATE TABLE [product] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [company_id] int NOT NULL,
  [product_category_id] int NOT NULL,
  [measurement_unit_id] int NOT NULL,
  [sku] nvarchar(100) NOT NULL,
  [name] nvarchar(200) NOT NULL,
  [catalog_entry_date] date NOT NULL,
  [is_active] bit NOT NULL DEFAULT (1),
  [created_at] datetime NOT NULL,
  [updated_at] datetime NOT NULL
)
GO

CREATE TABLE [product_packaging] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [product_id] int NOT NULL,
  [packaging_type_id] int NOT NULL,
  [units_in_package] decimal(10,2) NOT NULL,
  [created_at] datetime NOT NULL,
  [updated_at] datetime NOT NULL
)
GO

CREATE TABLE [warehouse] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [company_id] int NOT NULL,
  [country_id] int NOT NULL,
  [name] nvarchar(150) NOT NULL,
  [is_active] bit NOT NULL DEFAULT (1),
  [created_at] datetime NOT NULL,
  [updated_at] datetime NOT NULL
)
GO

CREATE TABLE [stock] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [product_id] int NOT NULL,
  [warehouse_id] int NOT NULL,
  [quantity] decimal(10,2) NOT NULL,
  [reorder_point] decimal(10,2) NOT NULL,
  [created_at] datetime NOT NULL,
  [updated_at] datetime NOT NULL
)
GO

CREATE TABLE [measurement_unit] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [company_id] int NOT NULL,
  [name] nvarchar(200) NOT NULL,
  [is_active] bit NOT NULL DEFAULT (1),
  [created_at] datetime NOT NULL,
  [updated_at] datetime NOT NULL
)
GO

CREATE TABLE [stock_movement] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [warehouse_from_id] int NOT NULL,
  [warehouse_to_id] int NOT NULL,
  [product_id] int NOT NULL,
  [quantity] decimal(10,2) NOT NULL,
  [created_at] datetime NOT NULL
)
GO

CREATE TABLE [reservation] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [product_id] int NOT NULL,
  [warehouse_id] int NOT NULL,
  [quantity] decimal(10,2) NOT NULL,
  [is_canceled] bit NOT NULL DEFAULT (0),
  [is_completed] bit NOT NULL DEFAULT (0),
  [expires_at] datetime NOT NULL,
  [created_at] datetime NOT NULL,
  [updated_at] datetime NOT NULL
)
GO

CREATE UNIQUE INDEX [company_index_0] ON [company] ("country_id", "vat_number")
GO

CREATE UNIQUE INDEX [tenant_user_index_1] ON [tenant_user] ("tenant_id", "email")
GO

CREATE UNIQUE INDEX [tenant_user_access_index_2] ON [tenant_user_access] ("tenant_user_id", "company_id")
GO

CREATE UNIQUE INDEX [packaging_type_index_3] ON [packaging_type] ("company_id", "name")
GO

CREATE UNIQUE INDEX [product_category_index_4] ON [product_category] ("company_id", "name")
GO

CREATE UNIQUE INDEX [product_index_5] ON [product] ("company_id", "sku")
GO

CREATE UNIQUE INDEX [product_packaging_index_6] ON [product_packaging] ("product_id")
GO

CREATE UNIQUE INDEX [warehouse_index_7] ON [warehouse] ("company_id", "name")
GO

CREATE UNIQUE INDEX [stock_index_8] ON [stock] ("product_id", "warehouse_id")
GO

CREATE UNIQUE INDEX [measurement_unit_index_9] ON [measurement_unit] ("company_id", "name")
GO

ALTER TABLE [tenant] ADD FOREIGN KEY ([currency_id]) REFERENCES [currency] ([id])
GO

ALTER TABLE [tenant_subscription] ADD FOREIGN KEY ([tenant_id]) REFERENCES [tenant] ([id])
GO

ALTER TABLE [tenant_subscription] ADD FOREIGN KEY ([subscription_type_id]) REFERENCES [subscription_type] ([id])
GO

ALTER TABLE [tenant_subscription] ADD FOREIGN KEY ([subscription_currency_id]) REFERENCES [currency] ([id])
GO

ALTER TABLE [company] ADD FOREIGN KEY ([country_id]) REFERENCES [country] ([id])
GO

ALTER TABLE [company] ADD FOREIGN KEY ([tenant_id]) REFERENCES [tenant] ([id])
GO

ALTER TABLE [tenant_user] ADD FOREIGN KEY ([tenant_id]) REFERENCES [tenant] ([id])
GO

ALTER TABLE [tenant_user_access] ADD FOREIGN KEY ([tenant_user_id]) REFERENCES [tenant_user] ([id])
GO

ALTER TABLE [tenant_user_access] ADD FOREIGN KEY ([company_id]) REFERENCES [company] ([id])
GO

ALTER TABLE [packaging_type] ADD FOREIGN KEY ([company_id]) REFERENCES [company] ([id])
GO

ALTER TABLE [product_category] ADD FOREIGN KEY ([company_id]) REFERENCES [company] ([id])
GO

ALTER TABLE [product] ADD FOREIGN KEY ([company_id]) REFERENCES [company] ([id])
GO

ALTER TABLE [product] ADD FOREIGN KEY ([product_category_id]) REFERENCES [product_category] ([id])
GO

ALTER TABLE [product] ADD FOREIGN KEY ([measurement_unit_id]) REFERENCES [measurement_unit] ([id])
GO

ALTER TABLE [product_packaging] ADD FOREIGN KEY ([product_id]) REFERENCES [product] ([id])
GO

ALTER TABLE [product_packaging] ADD FOREIGN KEY ([packaging_type_id]) REFERENCES [packaging_type] ([id])
GO

ALTER TABLE [warehouse] ADD FOREIGN KEY ([company_id]) REFERENCES [company] ([id])
GO

ALTER TABLE [warehouse] ADD FOREIGN KEY ([country_id]) REFERENCES [country] ([id])
GO

ALTER TABLE [stock] ADD FOREIGN KEY ([product_id]) REFERENCES [product] ([id])
GO

ALTER TABLE [stock] ADD FOREIGN KEY ([warehouse_id]) REFERENCES [warehouse] ([id])
GO

ALTER TABLE [measurement_unit] ADD FOREIGN KEY ([company_id]) REFERENCES [company] ([id])
GO

ALTER TABLE [stock_movement] ADD FOREIGN KEY ([warehouse_from_id]) REFERENCES [warehouse] ([id])
GO

ALTER TABLE [stock_movement] ADD FOREIGN KEY ([warehouse_to_id]) REFERENCES [warehouse] ([id])
GO

ALTER TABLE [stock_movement] ADD FOREIGN KEY ([product_id]) REFERENCES [product] ([id])
GO

ALTER TABLE [reservation] ADD FOREIGN KEY ([product_id]) REFERENCES [product] ([id])
GO

ALTER TABLE [reservation] ADD FOREIGN KEY ([warehouse_id]) REFERENCES [warehouse] ([id])
GO
