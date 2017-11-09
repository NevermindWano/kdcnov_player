# kdcnov_player ver. 0.1
Плеер для звукорежиссёра\звукооператора

Данный плеер предназначен для работы с фонотекой на различных культурно-масовых мероприятиях.

## СИСТЕМНЫЕ ТРЕБОВАНИЯ
 - OC Windows 7 и выше
 - Microsoft .NET Framework 4.6.1
 - AIMP версия не ниже 4 (не обязательно) 
 
## УСТАНОВКА и ЗАПУСК
  Установка не требуется, скачать и распаковать архив с Яндекс.Диска - https://yadi.sk/d/qXjAEG9S3PYz26. Запускается плеер файлом Kdcnov Player.exe

## ОБНОВЛЕНИЯ
 Все новые версии исплняемых файлов буду выкладывать на Яндекс.Диск - https://yadi.sk/d/qXjAEG9S3PYz26. Имя архива 
 "Kdcnov_Player_x" , где x - номер версии. Все изменения будут отражены в файле CHANGELOG.MD на github и CHANGELOG.TXT в архиве с исполняемыми файлами

## ЧТО УМЕЕТ
* Воспроизводить аудиотреки с помощью встроенного аудиоплеера или через AIMP
* Одновременно с аудиопотоком воспроизводит midi-трек или midi-ноту
* Одновременно со стартом аудиотрека посылает команду по OSC протоколу
* Разделяет треки на ОСНОВНОЙ и ФОНОВЫЙ
* Каждому треку назначается команда, что делать после его завершения ("воспроизвести следующий трек",
"воспроизвести случайный фоновый трек", "пауза" и тд.)
* Есть возможность создать ФОНОВЫЙ ПЛЕЙЛИСТ из которого случайным образом воспроизводятся треки 

## ЧЕМУ ПЛАНИРУЕТСЯ НАУЧИТЬ ПЛЕЕР
* Загружать файл сценария (docx) и привязывать к строчкам сценария треки
* В режиме "СЦЕНАРИЙ" менять тип трека с "ОСНОВНОЙ" на "ФОНОВЫЙ" без остановки воспроизведения, 
но с уменьшением громкости ("увести в фон")
* Синхронизация сигналов через midi и osc протоколы с bpm трека
* В данный момент OSC команды заточены ТОЛЬКО под взаимодействие с Resolume Arena, планирую реализовать возможность
слать настраиваемые ("кастомные") команды. 
* Возможность слать команды по OSC не только на старте трека но и вовремя воспроизведения трека,
в конкретный момент времени трека.
* Сейчас плеер понимает только номер midi-ноты, вскоре сделаю возможность назначать ноту по имени (напр. C4 или Db2)

# ИНСТРУКЦИЯ

## Основное окно
  Основной экран плеера состоит из двух частей: слева плйлист или сценарий, справа кнопки "ИГРАТЬ" и "СТОП". При первом старте плеера и при создания плейлиста появляется окно, с вопросом "Сформировать плейлист из файлов в папке? Иначе создаётся пустой плейлист". Если нажать "ДА", появится окно выбора папки, из которой создатся плейлист, в папке должны быть аудиофайлы (mp3 и\или wav). Иначе - пустой плейлист. Добавить треки в плейлист можно перетаскиванием или через меню "плейлист->добавить файл".

### Кнопка "СЛЕДУЮЩИЙ ТРЕК"
  Кнопка "СЛЕДУЮЩИЙ ТРЕК" запустит выделенный трек из плейлиста, при условии, что в данный момент состояние плеера "ОСТАНОВЛЕН" или "ИГРАЕТ ФОНОВЫЙ ТРЕК". Если в данный момент играет ОСНОВНОЙ трек, то плеер выдаст ошибку.

### Кнопка "СТОП"
  Кнопка "СТОП" остановит плеер. Если звучит ОСНОВНОЙ трек, то плеер спросит, точно ли вы хотите остановить его.

### Галочка "Всегда возвращать выделение на текущий трек"
  Если это галочка стоит, то когда курсор мыши выйдет за пределы плейлиста, будет выделен трек играющий сейчас или (если звучит трек из фонового плейлиста) на следующий.
  
### Скрыть фоновые треки
  Скрывает из отображения в плейплисте фоновых треков, но не удаляет их!
  
## Меню настройки
  При нажатии на пункт меню "Настройки", откроется окно настоек.
  
### Вкладка "Основные"
  В этой вкладке выбираем аудиоплеер. Рекомендуется AIMP. В стандартном плеере пока нет возможности управлять громкостью и делать плавное сведение треков. При выборе аудиоплеера AIMP, сведение треков настраивается в самом AIMP'e
  
  Также здесь выбираем midi-устройтво и адрес клиента для передачи данных по OSC протоколу. РАБОТАЕТ ПОКА ТОЛЬКО С RESOLUME ARENA!
  
### Вкладка "Фоновый плейлист"
  Здесь выбираем папку с треками (mp3 или wav файлы) для фонового плейлиста.
  MIDI Note - создаем список midi-нот, которые будут передаваться. Ноты выбираются из списка случайным образом при воспроизведении фонового плейлиста.
  OSC Tracks - создаём список номеров треков для Resolume Arena. В будущем планирую расширить функционал для OSC.
  
  
  В разделе "Основной оновый трек по умолчнию" выбираем этот трек и привязываем к нему midi-ноту и OSC трек
  
  
  В самом низу окна можно задать громкость фонового трека, значения от 0 до 100.
  
  
### Вкладка "Цвета и шрифты"
  Выбираем нужные цвета и шрифты для треков в плейлисте.
  
  
## Окно настроек трека
  Чтобы открыть окно настроек трека, нажмите правой кнопкой мыши на названии трека в плейлисте и выберите пункт контекстного меню "Настроить", либо сделайте двойной щелчёк мышью на названии трека.
  В окне настроек можно поменять название трека (имя файла не изменится), выбрать тип трека (ОСНОВНОЙ или ФОНОВЫЙ), 
задать количество ударов в минуту (BPM. Пока не работает. Нужно для синхронизации сигналов по midi и OSC протоколам).
  В пункте "После трека" можно выбрать, что произойдёт, когда проиграет трек:
    * Следующий трек - будеот воспроизведёт следующий трек в плейлисте. Если следующий трек фоновый, и стоит галочка "Скрыть фоновые треки" он всё равно будет воспроизведён, несмотра на то, что он не будет отображён в плейлисте.
    * Случайный фоновый трек - выбирается случайным образом из папки, которая определена в настройках на вкладке "ФОНОВЫЙ ПЛЕЙЛИСТ". Одновременно будут посланы сигналы по midi и osc протоколам выбранные случайном образом из списка в том же пункте меню.
    * Фоновый трек по умолчанию - будет воспроизведён трек, определённый в настройках на вкладке "ФОНОВЫЙ ПЛЕЙЛИСТ", в разделе "Фоновый трек по умолчанию"
    * Зациклить - Будет заново воспроизведён текущий трек, до тех пор, пока не пользователь не остановит плеер.
    * Пауза.

### Панель статуса
  В нижней части плеера отображается текущий статус: Играет ОСНОВНОЙ трек, ФОНОВЫЙ или ОСТАНОВЛЕНО.
   
  
  





