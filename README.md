# ProductsCategories
Данный проект является Web Api, где реализованны различные технологии в том числе использование SQL запроса из тестового задания
## SQL запрос для выбора всех пар «Имя продукта – Имя категории». Если у продукта нет категорий, то его имя все равно должно выводиться
```
"SELECT Products.Name AS NameProduct, COALESCE(Categories.Name, 'The product has no category') AS NameCategory " +
"FROM Products " +
"LEFT JOIN ProductsCategories ON Products.Id = ProductsCategories.IdProduct " +
"LEFT JOIN Categories ON ProductsCategories.IdCategory = Categories.Id"
```
## Развертывание проекта
Для того чтобы развернуть проект необходимо клонировать репозиторий и выполнить команту docker-compose up в корневой дериктории проекта.

## Доступные EndPoint
После развертывания проекта будут доступны следующие конечные точки
1. http://localhost:5050/product
    Данный EndPoint выводит список всех пар «Имя продукта – Имя категории», в том числе кепирует данные в Redis
2. http://localhost:5050/metrics
    Данный EndPoint выводит метрики совершенных запросов распределенных по 10 бакетам
