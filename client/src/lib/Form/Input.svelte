<script lang='ts'>
  export let value: string | undefined;
</script>

<label>
  <slot></slot>
  <input type="text" bind:value={value} />
</label>