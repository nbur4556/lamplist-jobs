<script lang="ts">
    export let onClose: () => void;
</script>

<button
    class="btn btn-sm btn-circle btn-ghost absolute right-2 top-2"
    on:click={onClose}
>
    ✕
</button>