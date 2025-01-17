import type { Config } from 'tailwindcss';
import daisyui from 'daisyui';

export default {
	content: ['./src/**/*.{svelte,js,ts}'],
	theme: {
		extend: {}
	},
	plugins: [daisyui],
	daisyui: {
		themes: ['business']
	}
} satisfies Config;
