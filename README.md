"Happy Rectangles" (Тестовое задание)
========

По клику на сцену добавляются прямоугольники разного цвета в то место, где был произведен клик. По двойному клику по прямоугольнику, он удаляется. Прямоугольники можно перетаскивать по сцене. Между прямоугольниками можно создавать/удалять связь (визуально - линия).

- Размер прямоугольников фиксирован (отношение сторон 2:1).
- Цвет создаваемого прямоугольника выбирается случайным образом в момент его создания.
- Прямоугольники не перекрывают друг друга ни при перетаскивании, ни при создании;
- Прямоугольник не создается, если область на сцене, по которой произведен клик, слишком мала для размещения в ней прямоугольника;
- При перетаскивании связанных прямоугольников связь сохраняется.
- При удалении прямоугольника связь удалятся;
- Количество созданных прямоугольников не ограничено.

### Особенности формирования связи:

- Создания связи между прямоугольниками осуществляется перетаскиванием прямоугольника к другому прямоугольнику (в момент касании формируется связь - линия), линия окрашена цветом прямоугольника от которого была сформирована связь;
- Удаления связи осуществляется повторным касанием прямоугольника от которого была сформирована связь с прямоугольником с которым была сформирована связь, либо с другим прямоугольником, в таком случае предыдущая связь удаляется и формируется новая (с новым прямоугольником);
- Определить кто источник связи можно по цвету линии формирующей связь;
