<script lang='ts'>
  export let value: string;
</script>

<label>
  <slot></slot>
  <input type="text" bind:value={value} />
</label>