<script lang="ts">
	import CloseWindowButton from '@src/lib/UI/CloseWindowButton.svelte';

	export let contentClass = '';
	export let isOpen: boolean = false;

	export const openModal = () => {
		if (isOpen === false) {
			isOpen = true;
		}
	};

	const closeModal = () => {
		if (isOpen === true) {
			isOpen = false;
		}
	};
</script>

<dialog
	class="modal"
	class:modal-open={isOpen}
	on:keydown={({ key }) => {
		if (key === 'Escape') {
			closeModal();
		}
	}}
>
	<section class={`modal-box ${contentClass}`}>
		<CloseWindowButton onClose={closeModal} />
		<slot />
	</section>
</dialog>
