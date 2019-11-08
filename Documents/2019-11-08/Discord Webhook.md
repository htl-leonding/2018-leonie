Super useful for us when this repo is used more frequently.

# [Copied from here](https://gist.github.com/jagrosh/5b1761213e33fc5b54ec7f6379034a22) and improved

# Step 1 - Make a Discord Webhook

1. Find the Discord channel in which you would like to send commits and other updates

   ![image1](https://i.imgur.com/hfaUSZJ.png)

2. In the settings for that channel, find the Webhooks option and create a new webhook. Note: Do NOT give this URL out to the public. Anyone or service can post messages to this channel, without even needing to be in the server. Keep it safe!

   ![WebhookDiscord](http://i.imgur.com/PZE2wFu.png)

# Step 2 - Set up the webhook on Github
# Use this URL `https://discordapp.com/api/webhooks/534345745327718420/iJ7zCXEdxr09zyHbz_IwuduiEn5K8juwrxh5JOUFdXre2GoUw0bP7oGb--1TMGpulnzL/github`

1. Navigate to your repository on Github, and open the Settings

   ![Settings](http://i.imgur.com/4GNq1lu.png)

2. Select Add Webhook

   ![Add](http://i.imgur.com/ZvrBQdi.png)

3. Paste in the webhook url and append `/github` to the end. Select "Send me everything", and then Add Webhook. **Make sure to set the Content type to application/json**

   ![WebhookSettings](http://i.imgur.com/mrf8Qmj.png)

4. Test it by updating something or starring the repository! If it works, you're all set!

   ![Star](http://i.imgur.com/ABlwTLf.png)
