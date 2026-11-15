# BooKids

Windows Forms management application for a children's activity / toy business, developed for the **DA (Desenvolvimento de Aplicações)** course, 1st year / 2nd semester of the TeSP in Programação de Sistemas de Informação (IPL).

## Authors

- Eduardo Amado (2202420)
- João Fernandes (2201158)
- Tiago Tavares (2202418)

## Features

The application manages:

- **People**: clients (`Cliente`), children (`Filho`) and entertainers (`Animador`)
- **Schools** (`Escola`)
- **Events** (`Evento`), with registrations (`Inscricao`), participations (`Participacao`) and collaborations (`Colaboracao`)
- **Products** and product types (`Produto`, `TipoProduto`)
- **Purchases** (`Compra`) and purchase details (`DetalheCompra`), including a sold-products view
- **PDF export** of data using iTextSharp

## Tech stack

- C# / Windows Forms, .NET Framework 4.7.2
- Entity Framework 6.2 (Model First, `DA_BooKids.edmx`)
- SQL Server LocalDB (`(localdb)\MSSQLLocalDB`)
- iTextSharp (`itextsharp.dll`, included in the project folder)

## Project structure

```
Projeto_DA_BooKids/
├── Forms/                    # Windows Forms (main form FBooKids + one form per entity)
├── *.cs                      # Entity classes generated from the EF model
├── DA_BooKids.edmx           # Entity Framework model
├── DA_BooKids.edmx.sql       # Script that creates the database schema
├── ExportToPdf.cs            # PDF export helper
├── App.config                # Connection strings
└── Projeto_DA_BooKids.sln
```

## Setup

1. Open `Projeto_DA_BooKids.sln` in Visual Studio and restore the NuGet packages (Entity Framework 6.2).
2. In **View → SQL Server Object Explorer**, expand `(localdb)\MSSQLLocalDB`, right-click **Databases → Add New Database** and create a database named exactly **`BooKids_DB`**.
3. Open `DA_BooKids.edmx.sql` (it should contain `USE [BooKids_DB]` near the top) and run it against that database.
4. Build and run the project (F5).

## Known issues / tips

- **"Erro Fatal Desconhecido"** on the binding navigator: when adding a row, click **+** only once, fill in the fields, then click **Save**. Clicking **+** twice in a row triggers this error.
- **"Erro ao Gravar"** when saving: usually caused by a foreign key that does not exist in the referenced table. Make sure the referenced record exists first.

A full project report is available in `../Relatório_Projeto_DA.pdf`.
