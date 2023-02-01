<script lang="ts">
	import Input from '@src/lib/Form/Input.svelte';
	import PasswordInput from '@src/lib/Form/PasswordInput.svelte';

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

	const onSubmit = () => {
		if (formValues.password !== formValues.confirmPassword) {
			//TODO: Display Error Message
			console.error('Password and confirm password do not match');
			return;
		}

		console.log(formValues);
	};
</script>

<main>
	<form on:submit={onSubmit}>
		<Input bind:value={formValues.userName}>UserName</Input>
		<PasswordInput bind:value={formValues.password}>Password</PasswordInput>
		<PasswordInput bind:value={formValues.confirmPassword}>Confirm Password</PasswordInput>
		<button type="submit">Submit</button>
	</form>
</main>
