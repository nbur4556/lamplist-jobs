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
		justify-content: center;
		padding: sizes.$spacing-md;
	}
</style>
