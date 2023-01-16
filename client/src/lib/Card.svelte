<section>
  <slot />
</section>

<style lang='scss'>
  // ? Does this have to be a relative path?
  @use '../theme/colors.scss';
  @use '../theme/sizes.scss';

  section {
    padding: 20px;
    border: sizes.$border solid colors.$black;

    width: max-content;

    box-shadow: sizes.$border sizes.$border colors.$black;
  }
</style>
