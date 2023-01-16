<section>
  <slot />
</section>

<style lang='scss'>
  // ? Does this have to be a relative path?
  @use '../theme/colors';
  @use '../theme/effects';
  @use '../theme/sizes';

  section {
    margin: sizes.$spacing-small;
    padding: sizes.$spacing-mid;
    border: sizes.$border solid colors.$black;

    width: max-content;

    box-shadow: effects.$container-shadow;
  }
</style>
