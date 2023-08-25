
<script lang="ts">
	import { goto } from '$app/navigation';

	import Input from '@src/lib/Form/Input.svelte';
	import PageContent from '@src/lib/UI/PageContent.svelte';
	import PasswordInput from '@src/lib/Form/PasswordInput.svelte';
	import PasswordRequirements from '@src/lib/PasswordRequirements.svelte';
	import { AuthStore } from '@src/store/AuthStore';

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

	let errorMessage = '';

	const clearResultMessages = () => {
		errorMessage = '';
	};

	const onSubmit = async () => {
		try {
			if (!formValues.userName || !formValues.password) {
				throw 'UserName and Password are required';
			}
			if (formValues.password !== formValues.confirmPassword) {
				throw 'Password and confirm password do not match';
			}

			await AuthStore.register(formValues.userName, formValues.password);
			goto('/');
		} catch (err) {
			errorMessage = `Error: ${JSON.stringify(err)}`;
			console.error(errorMessage);
		}
	};
</script>

<PageContent>
	<a class="link link-primary" href="/">Home</a>
	<h1 class="text-2xl">Register</h1>
	<form class="w-full" on:change={clearResultMessages} on:submit={onSubmit}>
		<Input bind:value={formValues.userName}>UserName</Input>
		<PasswordInput bind:value={formValues.password}>Password</PasswordInput>
		<PasswordInput bind:value={formValues.confirmPassword}>Confirm Password</PasswordInput>
		<button class="btn btn-primary mt-2" type="submit">Submit</button>
	</form>
	<p class="text-error">{errorMessage}</p>
	<PasswordRequirements />
</PageContent>
