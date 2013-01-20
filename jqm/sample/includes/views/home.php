<?php render('_header',array('title'=>$title))?>
<p>Pozdravljeni, pred vami je primer mobilne spletne predstavitve kataloga artiklov.
<br>Preizkusite dostopati z več mobilnimi napravami.</p>
<ul data-role="listview" data-inset="true" data-theme="a" data-dividertheme="a">
    <li data-role="list-divider" data-theme="a">Izberite oddelek</li>
    <?php render($content) ?>
</ul>

<?php render('_footer')?>