<script lang="ts">
	import Input from '@src/lib/Form/Input.svelte';
	import PasswordInput from '@src/lib/Form/PasswordInput.svelte';

	interface FormValues {
		userName?: string;
		password?: string;
	}

	let formValues: FormValues = {
		userName: undefined,
		password: undefined
	};

	const onSubmit = () => {
		console.log(formValues);
	};
</script>

<main>
	<form on:submit={onSubmit}>
		<Input bind:value={formValues.userName}>UserName</Input>
		<PasswordInput bind:value={formValues.password}>Password</PasswordInput>
		<button type="submit">Submit</button>
	</form>
</main>
