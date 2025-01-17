<script lang="ts">
	import CloseIcon from '../Icons/CloseIcon.svelte';
	export let onClose: () => void;
</script>

<button class="btn btn-sm btn-ghost absolute right-2 top-2" on:click={onClose}>
	<CloseIcon class="w-4 h-4" strokeWidth="2" />
</button>
