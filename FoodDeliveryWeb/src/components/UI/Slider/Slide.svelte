<script>
    let slideProps = {
        class: $$restProps.class
    };
</script>

<div class={slideProps.class}>
    <slot />
</div>

<style>
    div {
        display: inline-block;
    }
</style>
