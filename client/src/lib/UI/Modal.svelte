<script lang="ts">
    export let isOpen: boolean = false;

    const closeModal = () => (isOpen = false);
</script>

<dialog class="modal" class:modal-open={isOpen}>
    <section class="modal-box">
        <button
            class="btn btn-sm btn-circle btn-ghost absolute right-2 top-2"
            on:click={closeModal}
        >
            ✕
        </button>
        <p>
            <slot />
        </p>
    </section>
</dialog>