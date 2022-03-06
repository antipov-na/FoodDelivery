<script>
</script>

<div class="column">
    <slot name="header" />
    <ul class="links">
        <slot />
    </ul>
</div>

<style>
    .column {
        min-width: var(--column-min-width, 0);
        max-width: var(--column-max-width, unset);
    }

    .links {
        margin: 0;
        display: flex;
        flex-direction: column;
        gap: var(--links-gap, 5px);
    }
</style>
