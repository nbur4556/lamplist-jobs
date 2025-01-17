<script lang="ts">
	export let onClick: () => void;
</script>

<button class="btn btn-outline btn-xs" on:click={onClick}>
	<slot />
</button>
