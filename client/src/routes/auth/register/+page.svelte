<script lang="ts">
	import Input from '@src/lib/Form/Input.svelte';

	interface FormValues {
		userName?: string;
		password?: string;
		confirmPassword?: string;
	}

	let formValues: FormValues = {
		userName: undefined,
		password: undefined,
		confirmPassword: undefined
	};
</script>

<main>
	<form>
		<Input bind:value={formValues.userName}>UserName</Input>
		<Input bind:value={formValues.userName}>Password</Input>
		<Input bind:value={formValues.userName}>Confirm Password</Input>
		<button type="submit">Submit</button>
	</form>
</main>
