<section>
	<div class="header">
		<slot name="header" />
	</div>
	<div class="body">
		<slot />
	</div>
</section>

<style lang="scss">
	// ? Does this have to be a relative path?
	@use '../../theme/colors';
	@use '../../theme/sizes';

	section {
		display: flex;
		flex-direction: column;

		margin: sizes.$spacing-sm 0;
		padding: sizes.$spacing-sm;

		width: 100%;

		background-color: colors.$bg-mid;
		border-radius: 10px;

		.header {
			padding-bottom: sizes.$spacing-sm;
		}

		.body {
			color: colors.$txt-sub;
		}
	}
</style>
