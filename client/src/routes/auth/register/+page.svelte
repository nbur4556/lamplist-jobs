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
	<h1>Register</h1>
	<a href="/">Home</a>
	<form on:change={clearResultMessages} on:submit={onSubmit}>
		<Input bind:value={formValues.userName}>UserName</Input>
		<PasswordInput bind:value={formValues.password}>Password</PasswordInput>
		<PasswordInput bind:value={formValues.confirmPassword}>Confirm Password</PasswordInput>
		<button type="submit">Submit</button>
	</form>
	<p class="error-message">{errorMessage}</p>
	<PasswordRequirements />
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

	.error-message {
		color: colors.$accent-mid;
	}
</style>
