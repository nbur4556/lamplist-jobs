<script lang="ts">
    import CloseWindowButton from "@src/lib/UI/CloseWindowButton.svelte";

    export let isOpen: boolean = false;

    const closeModal = () => (isOpen = false);
</script>

<dialog class="modal" class:modal-open={isOpen}>
    <section class="modal-box">
        <CloseWindowButton onClose={closeModal} />
        <slot />
    </section>
</dialog>