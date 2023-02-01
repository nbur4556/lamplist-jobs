<script lang="ts">
	import Input from '@src/lib/Form/Input.svelte';
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

	const onSubmit = () => {
		if (!formValues.userName || !formValues.password) {
			console.error('UserName and Password are required');
			return;
		}

		AuthStore.loginUser(formValues.userName, formValues.password);
	};
</script>

<main>
	<a href="/">Home</a>
	<form on:submit={onSubmit}>
		<Input bind:value={formValues.userName}>UserName</Input>
		<PasswordInput bind:value={formValues.password}>Password</PasswordInput>
		<button type="submit">Submit</button>
	</form>
</main>
