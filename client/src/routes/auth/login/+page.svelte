<script lang="ts">
	import Input from '@src/lib/Form/Input.svelte';
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

	let successMessage = '';
	let errorMessage = '';

	const clearResultMessages = () => {
		successMessage = '';
		errorMessage = '';
	};

	const onSubmit = async () => {
		if (!formValues.userName || !formValues.password) {
			errorMessage = 'Error: UserName and Password are required';
			console.error(errorMessage);
			return;
		}

		const response = await AuthStore.login(formValues.userName, formValues.password);
		if (response.type === 'error') {
			errorMessage = `Error: ${response.message}`;
			console.error(errorMessage);
		} else {
			// TODO: Should reroute to home on success
			successMessage = `User ${formValues.userName} logged in`;
		}
	};
</script>

<PageContent>
	<h1>Log In</h1>
	<a href="/">Home</a>
	<form on:change={clearResultMessages} on:submit={onSubmit}>
		<Input bind:value={formValues.userName}>UserName</Input>
		<PasswordInput bind:value={formValues.password}>Password</PasswordInput>
		<button type="submit">Submit</button>
	</form>
	<p class="success-message">{successMessage}</p>
	<p class="error-message">{errorMessage}</p>
</PageContent>

<style lang="scss">
	@use '../../../theme/colors';
	@use '../../../theme/sizes';

	h1 {
		font-size: sizes.$font-lg;
	}

	form {
		display: flex;
		flex-direction: column;
		gap: sizes.$spacing-md;

		width: 100%;
	}

	.success-message {
		color: green;
	}

	.error-message {
		color: colors.$accent-mid;
	}
</style>
