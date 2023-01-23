<script>
  import { fly } from 'svelte/transition';
</script>

<!-- //TODO: Animation should be passed as props -->
<section in:fly={{x: 1000, duration: 500}} out:fly={{x: -1000, duration: 500}}>
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

    // TODO: Should only be position absolute if passed as a prop OR should have styling options passed as props
    position: absolute;
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
