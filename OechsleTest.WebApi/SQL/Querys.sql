create table dbo.Employee
(
id int identity primary key,
name varchar(50),
document_number varchar(8),
salary decimal(10,2),
age int,
profile varchar(30),
admission_date datetime
)


go


insert into dbo.Employee(name,document_number,salary,age,profile,admission_date)
values
('Nancy Davolio','t', 2800,22,'Secretary', '20200102'),
('Robert Diaz','1256789', 2300,38,'Developer', '20200102'),
('Juan Lopez','2256789', 5300,35,'Administrator', '20200102'),
('Julia Madrid','3256789', 6300,37,'Administrator', '20200102'),
('Dan Rogers','4236789', 2300,36,'QA', '20200102'),
('Luis Noriega','5256789', 2300,35,'Administrator', '20210102'),
('Maria Salas','6256789', 1300,55,'Developer', '20210102'),
('Albert Salazar','5126789', 10300,35,'Director', '20210102'),
('Sol Quispe','7256789', 2200,35,'Administrator', '20210102'),
('Angie Quiroz','8256789', 2300,35,'Administrator', '20210102'),
('Elena Ramirez','09632145', 1800,22,'Secretary', '20220102'),
('Juana Martinez','1256789', 2300,35,'Developer', '20220102'),
('Anthonella Quesada','1156789', 2300,35,'Developer', '20220102'),
('Alejandro Ruiz','1256789', 2300,35,'Developer', '20220102'),
('Jimena Salas','1356789', 4300,35,'Developer', '20220102'),
('Claudia Diaz','1456789', 5300,35,'Support', '20220102'),
('Jessi Diaz','1556789', 6300,35,'Designer', '20220102'),
('Brenda Cornejo','1656789', 2300,36,'Developer', '20220102'),
('Pedro Diaz','1756789', 2300,35,'QA', '20220102'),
('Jesus Ramirez','4256789', 2300,35,'QA', '20220102')


