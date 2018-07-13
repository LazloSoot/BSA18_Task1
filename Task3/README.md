﻿# BSA18_Task3
###### REST API (.NET)

Решением данного домашнего задания является текстовый документ (Google Docs) со спроектированным REST API для следующей предметной области:

Аэропорт обслуживает полеты самолетов с назначенными рейсами. Дата/Время вылета может отличаться от времени отправления рейса - например если рейс задержали, то соответственно время вылета будет с задержкой. Для вылета назначается самолет и экипаж. Экипаж состоит из пилота (1) и стюардесс (1 или более). Самолеты, которые принадлежат аэропорту, имеют срок эксплуатации в зависимости от типа самолета и требуют своевременного технического обслуживания.

Мы, как диспетчеры должны иметь CRUD операции над всеми сущностями.

Классы должны выглядеть таким образом:

 * Рейсы (номер рейса, пункт отправления, время отправления, пункт назначения, время прилета в назначенное место, билет)

 * Билет (Id, цена, номер рейса)

 * Вылеты (Id, номер рейса, дата вылета, экипаж, самолет)

 * Стюардессы (Id, Имя, Фамилия, Дата Рождения)

 * Пилоты (Id, Имя, Фамилия, Дата Рождения, Опыт (например 3 года))

 * Экипаж (Id, Пилот (1), Стюардессы (1 или более)

 * Самолет (Id, Название самолета, Тип самолета, Дата выпуска самолета с завода, срок эксплуатации (TimeSpan)

 * Типы самолетов (Id, модель самолета, кол-во мест, грузоподъемность(кг)) 