<script>
</script>

<nav>
    <slot />
</nav>

<style>
    nav {
        display: var(--display, flex);
        gap: var(--gap, 0);
        justify-content: var(--justify-content, unset);
        align-items: var(--align-items, unset);
    }
</style>
