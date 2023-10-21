<script lang="ts">
	export let tooltip: string;
	export let onClick: () => void;
	let className: string = '';
	export { className as class };
</script>

<!-- //TODO: Use for all icon buttons -->
<div class="tooltip" data-tip={tooltip}>
	<button class={className} on:click={onClick}>
		<slot />
	</button>
</div>
