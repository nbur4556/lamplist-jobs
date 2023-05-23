<section class="page-content">
	<slot />
</section>

<style lang="scss">
	@use '../../theme/sizes';

	.page-content {
		display: flex;
		flex-direction: column;
		align-items: center;
		gap: sizes.$spacing-sm;
	}
</style>
