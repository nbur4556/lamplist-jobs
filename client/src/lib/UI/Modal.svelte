<script lang="ts">
	import CloseWindowButton from '@src/lib/UI/CloseWindowButton.svelte';

	let isOpen: boolean = false;

	export const openModal = () => {
		if (isOpen === false) {
			isOpen = true;
		}
	}

	const closeModal = () => {
		if (isOpen === true) {
			isOpen = false;
		}
	}
</script>

<dialog class="modal" class:modal-open={isOpen}>
	<section class="modal-box">
		<CloseWindowButton onClose={closeModal} />
		<slot />
	</section>
</dialog>
