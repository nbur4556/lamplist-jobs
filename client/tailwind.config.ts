import type { Config } from 'tailwindcss';
import daisyui from 'daisyui';

// TODO: 202412-package-update: ensure no broken styles after all updates complete
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
