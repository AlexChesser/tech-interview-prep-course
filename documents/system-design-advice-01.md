# how I cleared L6 System Design - Part 1

Reference <https://www.teamblind.com/post/Giving-back---how-I-cleared-L6-System-Design---Part-1-4yufM3RY>

## 1. Intro

I spent 6 months preparing overall. In the evenings before going to sleep I'd spend some time on Blind to get my hopes up and see a joke or two. There are some assholes here and there on Blind, but the majority are good people. I love you all. So now that I'm 'across the river' I decided to give back and provide some hints specifically on the System Design rounds.

I interviewed at Amazon, Twitter, Google, Facebook, Databricks and Elastic for L6 (or L6 equivalent). I cleared them all with exception of Twitter. I cleared Google and Facebook first then had 'emergency' interviews with the rest of the companies to ensure I was well-placed for the inevitable lowballing dance. One Friday I had half-onsite with Elastic in the morning and half-onsite with Twitter in the evening. I completely messed up the System Design for Twitter and that killed my prospects. I regret that though, as I liked Twitter.

I am not a genius, I'm just a hardworking tenacious guy. Don't let anyone tell you you're not smart enough for L6. It's all about mustering the motivation, channeling the work and executing it well.

I made the decision to try 6 months ago, and I prepared throughout that time while being at work. So my preparation hints will suppose long-term prep. If you're expecting a two-week crash course this is not for you.

I'm conscious some of this intro will read like a flex - it is genuinely not - but I'm sure the context will be helpful to many so I decided to make that tradeoff ;)

## 2. Content

Where do you start? Get the Designing Data Intensive Applications book. This will fill your theoretical gaps. Read it slowly. *Do not make fake progress*. If you don't understand something stop, use the references, research the subjects, get out of the book and back. There is *nothing* useless for you in that book. Nothing too much. It's all for you cover to cover. Properly grasping that book is half of the whole work. Part 1 is super useful to teach you how to pick data stores. Part 2 will dispel your fears of sharding and choosing a replication mechanism. Part 3 will give you a full idea on how to piece a big system together from smaller systems. The separation of System of record and derived data is key to understand there.

When you think you're done with DDIA, if I wake you up in the middle of the night you should be able to explain to me how LSMT-based databases use Red Black Trees to keep a sorted log in memory and why they do that, and then get back to sleep. I'm serious.

Next up, pay for Grokking the system design interview.

I know that Grokking can be too shallow. Nevertheless, I want you to be able to recite the solutions in Grokking down to the smallest details. Details are more important than the big picture for L6. Do you think your done with typeahead suggestions? Did you mention exponential moving average on how you weigh results? No? Failed.

You can leave the pastebin and bitly and that easy crap uncovered, but I'll need you to recite the other grokking solutions to the smallest details. Take extra care on the geospatial problems. If I show up at your lunch and ask you about quad trees I want you to be able to estimate the index size on the spot. You can't? Not ready yet.

Next up: videos. InfoQ and @scale videos about real life systems. Look up Nathan Bronson and suck up all his videos on Tao, Caches etc. Look up Nishtala and the memcache video. Look up Kulkarni and the Facebook live video. Look up Susheel Aroskar and his Zuul push video <- ultra useful.

Again, never make fake progress. Take this last one: Aroskar's Zuul push. He mentions Apache Netty. Read up on it, understand it. Go deeper, understand epoll and its red black trees. Go deeper and understand the TIMED-WAIT trick in TCP protocol which saves some web sockets connections. Another thing: he mentions some load balancers can't handle websockets. Why? Go figure it out. I did and I impressed my Facebook interviewer as I went deep until I was stopped as the interviewer lost it. L6 means depth, depth, depth. If you draw me a block that says 'Server' and leave it at that I'll slap you back to L3.

Now I went the extra mile. But I wasn't targeting barely making it - I was targeting mind-blowing performance. If you want the hardcore stuff, let me know and I'll give you content for that as well. If you're up for anecdotes, a Google interviewer challenged me on Paxos when I mentioned Spanner to him. I drew the multi-Paxos detailed flow for him with estimated latencies supposing a 5-replica configuration with the pivot replica on north-east US. He smiled and said 'ok' (Strong hire).

Next up, the Google SRE book. Did you say you're not interviewing for SRE? Don't care. You don't need it all. You do need the chapter on Non-Abstract Large System Design. You need to be able to recite that in your sleep. Especially the estimations part. You don't have NALSD interview? *rolls eyes* Don't care, learn the NALSD chapter or fail.

## 3. Speaking of Estimations

Ultra important. If you can't handle these, you're most likely ducked. How do you prepare for them? Practice power of 10 calculations. See how the NALSD chapter does it. Practice with fake numbers. Drag the units with you and reduce them when dividing/multiplying.

When calculating storage, consider cold storage. Also consider e.g. cassandra needs ±30% free space to do compacting (see, I told you to properly learn LSTMs in Part 1 of DDIA), also keep in mind that only ±85% of the disk space is usable (OS files, formatting tables etc.), also keep in mind that 3-5% of disks die in a year so account for that, also keep in mind that you need to multiply by replication factor, also keep in mind that cassandra says no more than 2TB disks otherwise it gets slow.

Have a strong grasp on the -bound concepts. Is something storage-bound (Log dumps)? Is something cpu-bound (live stream encoding)? Is something RAM bound (in-memory timeline serving)? Once you grasp those you design tiers with separate scaling techniques. That's why you need numbers, not to show off your math but to figure the -bound part and then decide how to scale a specific tier.

I'll wrap up this part here. In the second part I'll get into some sample walk-throughs of some popular questions. Then I'll give a you a detailed plan on how to spend the 45 minutes. I did 9 System Design interviews in the space of 5 weeks so it's fresh in my head.

Now you might think this is a lot of work. It is. It depends on how much you want the job. Want it badly? Throw in the effort then, that's all it takes. Was it worth the effort for me? Yes.

Old TC: 175K USD, New TC: 593k USD
