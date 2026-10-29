using System;
using laba1Nikitin;

Dimensions keyboardDimensions = new Dimensions(0.8, 0.01, false);
Dimensions mouseDimensions = new Dimensions(0.2, 0.003, false);
Dimensions monitorDimensions = new Dimensions(5.5, 0.08, true);

Product keyboard = new Product("A001", "Клавиатура", 5000, 10, 3, keyboardDimensions);
Product mouse = new Product("A002", "Мышь", 2000, 2, 5, mouseDimensions);
Product monitor = new Product("A003", "Монитор", 25000, 4, 2, monitorDimensions);

Warehouse warehouse = new Warehouse(10);
warehouse.DoseProduct(keyboard);
warehouse.DoseProduct(mouse);
warehouse.DoseProduct(monitor);

Console.WriteLine("Товары на складе:");
foreach (Product product in warehouse.GetProducts())
    Console.WriteLine(product);

Console.WriteLine($"\nСоздано товаров: {Product.GetCreatedProducts()}");
Console.WriteLine($"Общая стоимость склада: {warehouse.GetMnogoValue()}");
Console.WriteLine($"Цена клавиатуры с НДС: {keyboard.priceWithTax()}");
Console.WriteLine($"Цена клавиатуры с налогом 20%: {keyboard.priceWithTax(0.20)}");

Product? found = warehouse.FindByArticle("A001");
Console.WriteLine($"\nПоиск A001: {found}");

Console.WriteLine("\nОтгружаем две клавиатуры:");
warehouse.ShipByArticle("A001", 2);
Console.WriteLine(keyboard);

Console.WriteLine("\nТовары ниже минимального остатка:");
foreach (Product product in warehouse.GetLowRestProducts())
    Console.WriteLine(product);

Console.WriteLine("\nПроверка защиты от ошибок:");
try { warehouse.ShipByArticle("A001", 100); }
catch (Exception ex) { Console.WriteLine($"Ошибка отгрузки: {ex.Message}"); }

try { keyboard.ChangePrice(-1); }
catch (Exception ex) { Console.WriteLine($"Ошибка цены: {ex.Message}"); }

try { new Product("", "Неверный товар", 100, 1, 0, keyboardDimensions); }
catch (Exception ex) { Console.WriteLine($"Ошибка артикула: {ex.Message}"); }

Console.WriteLine($"Количество успешно созданных товаров: {Product.GetCreatedProducts()}");

Product[] outsideProducts = warehouse.GetProducts();
outsideProducts[0] = monitor;
Console.WriteLine($"\nПосле подмены элемента копии первый товар склада: {warehouse.GetProducts()[0].Name}");

Dimensions receivedDimensions = keyboard.Dimensions;
receivedDimensions = new Dimensions(100, 5, true);
Console.WriteLine($"Вес в новой локальной переменной: {receivedDimensions.Weight}");
Console.WriteLine($"Вес клавиатуры не изменился: {keyboard.Dimensions.Weight}");

keyboard.ChangeDimensions(new Dimensions(1.0, 0.015, false));
Console.WriteLine($"Вес клавиатуры после замены Dimensions целиком: {keyboard.Dimensions.Weight}");
