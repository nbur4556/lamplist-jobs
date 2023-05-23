<script>
	import '@src/styles/global.scss';
</script>

<main>
	<slot />
</main>

<style lang="scss">
	@use '../theme/sizes';

	main {
		display: flex;
		flex-direction: column;
		align-items: center;
		gap: sizes.$spacing-sm;

		padding: sizes.$spacing-md;
	}
</style>
