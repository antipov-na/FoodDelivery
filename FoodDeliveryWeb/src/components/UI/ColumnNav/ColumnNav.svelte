<script>
</script>

<div class="columnNav">
    <slot />
</div>

<style>
    .columnNav {
        display: flex;
        background-color: var(--background-color, unset);
        padding: var(--padding, 0);
        border-radius: var(--border-radius, 0);
        gap: var(--column-gap, 0);
    }
</style>
