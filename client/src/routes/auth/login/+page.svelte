<script lang="ts">
	import { goto } from '$app/navigation';

	import Input from '@src/lib/Form/Input.svelte';
	import NavigationBar from '@src/lib/NavigationBar.svelte';
	import PageContent from '@src/lib/UI/PageContent.svelte';
	import PasswordInput from '@src/lib/Form/PasswordInput.svelte';
	import { AuthStore } from '@src/store/AuthStore';

	interface FormValues {
		userName?: string;
		password?: string;
	}

	let formValues: FormValues = {
		userName: undefined,
		password: undefined
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

			await AuthStore.login(formValues.userName, formValues.password);
			goto('/');
		} catch (err) {
			errorMessage = `Error: ${JSON.stringify(err)}`;
			console.error(errorMessage);
		}
	};
</script>

<PageContent>
	<NavigationBar>
		<a slot="left" class="link link-primary" href="/">Home</a>
	</NavigationBar>
	<h1 class="text-2xl">Log In</h1>
	<form class="w-full" on:change={clearResultMessages} on:submit={onSubmit}>
		<Input bind:value={formValues.userName}>UserName</Input>
		<PasswordInput bind:value={formValues.password}>Password</PasswordInput>
		<button class="btn btn-primary mt-2" type="submit">Submit</button>
	</form>
	<p class="text-error">{errorMessage}</p>
</PageContent>
