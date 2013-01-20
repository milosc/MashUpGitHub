<li <?php echo ($active == $category->id ? 'data-theme="a"' : 'data-theme="a"') ?>>
<a href="?category=<?php echo $category->id?>" data-transition="fade" data-theme="a">
	<?php echo $category->name ?>
    <span class="ui-li-count"><?php echo $category->contains?></span></a>
</li>