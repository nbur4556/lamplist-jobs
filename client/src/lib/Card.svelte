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
	@use '../theme/colors';
	@use '../theme/effects';
	@use '../theme/sizes';

	section {
		display: flex;
		flex-direction: column;

		margin: sizes.$spacing-sm;
		border: sizes.$border solid colors.$black;

    width: max-content;
		box-shadow: effects.$container-shadow;

		.header {
			padding: sizes.$spacing-sm;
			background-color: colors.$base;
		}

		.body {
			padding: sizes.$spacing-sm;
		}
	}
</style>
