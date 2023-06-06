<script lang="ts">
	export let onClick: () => void;
</script>

<button on:click={onClick}>
	<slot />
</button>

<style lang="scss">
	@use '../../theme/colors';

	button {
		padding: 0;

		color: colors.$txt-main;
		background: none;
		text-decoration: underline;

		&:hover {
			color: colors.$txt-sub;
			cursor: pointer;
		}
	}
</style>
