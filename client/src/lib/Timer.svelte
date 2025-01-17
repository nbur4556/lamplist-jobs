<script lang="ts">
	import PlayIcon from '@src/lib/Icons/PlayIcon.svelte';
	import PauseIcon from '@src/lib/Icons/PauseIcon.svelte';
	import TooltipButton from './UI/TooltipButton.svelte';

	export let time: number;
	export let onStopTime: (remaining: number) => void;

	let timer: number;
	let passed = 0;
	let isRunning = false;

	export const resetTimer = () => {
		stopTimer();
		passed = 0;
	};

	const startTimer = () => {
		timer = setInterval(() => {
			if (passed > time - 1) {
				stopTimer();
				return;
			}

			passed++;
		}, 1_000);
		isRunning = true;
	};

	const stopTimer = () => {
		clearInterval(timer);
		isRunning = false;
		onStopTime(remaining);
	};

	$: remaining = time - passed;
	$: minutes = Math.floor(remaining / 60);
	$: seconds = remaining % 60;
</script>

<div class="flex gap-2">
	<p>
		<span class="countdown">
			<span id="counterElement" style={`--value:${minutes};`} />:
			<span id="counterElement" style={`--value:${seconds};`} />
		</span>
	</p>
	{#if isRunning}
		<TooltipButton tooltip="Pause" onClick={stopTimer}>
			<PauseIcon />
		</TooltipButton>
	{:else}
		<TooltipButton tooltip="Play" onClick={startTimer}>
			<PlayIcon />
		</TooltipButton>
	{/if}
</div>
