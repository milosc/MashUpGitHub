<?php render('_header',array('title'=>$title))?>

<div class="rightColumn" data-theme="a">
	<ul data-role="listview" data-inset="true" data-theme="a" data-dividertheme="a">
	 <li data-role="list-divider" data-theme="a">Arikli</li>
        <?php render($products) ?>
    </ul>
</div>

<div class="leftColumn" data-theme="a">
    <ul data-role="listview" data-inset="true" data-theme="a" data-dividertheme="a">
        <li data-role="list-divider" data-theme="a">Oddelki</li>
        <?php render($categories,array('active'=>$_GET['category'])) ?>
    </ul>
</div>

<?php render('_footer')?>